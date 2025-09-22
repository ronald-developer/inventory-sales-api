using AutoMapper;
using InventorySales.Contracts;
using InventorySales.EntityFramework;
using InventorySales.Models.AccountManager;
using InventorySales.Models.AppSettings;
using InventorySales.Models.ExceptionTypes;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InventorySales.Implementations
{
    public class AccountManagerService : IAccountManagerService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;
        private readonly IJwtManager jwtManager;
        private readonly JwtSettings jwtSettings;
        private readonly IConfiguration configuration;
        private readonly IdentityTokenSettings identityTokenSettings;
        private AppUser user;

        public AccountManagerService(
            UserManager<AppUser> userManager,
            IMapper mapper,
            IOptions<JwtSettings> jwtSettings,
            IOptions<IdentityTokenSettings> identityTokenSettings,
            IJwtManager jwtManager)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.jwtManager = jwtManager;
            this.jwtSettings = jwtSettings.Value;
            this.identityTokenSettings = identityTokenSettings.Value;
        }

        public async Task<TokenModel> Login(LoginModel model)
        {
            var emailAttribute = new System.ComponentModel.DataAnnotations.EmailAddressAttribute();
            bool isUsernameEmail = emailAttribute.IsValid(model.Username);

            if (isUsernameEmail)
            {
                user = await userManager.FindByEmailAsync(model.Username);
            }
            else
            {
                user = await userManager.FindByNameAsync(model.Username);
            }

            bool isValidUser = await userManager.CheckPasswordAsync(user, model.Password);

            if (user == null || isValidUser == false)
            {
                throw new UnauthorizedException();
            }

            string token = await jwtManager.GenerateTokenAsync(user);
            string refreshToken = await jwtManager.CreateRefreshToken(user);

            return new TokenModel
            {
                UserId = user.Id,
                Token = token,
                RefreshToken = refreshToken
            };
        }

        public async Task<string> Register(UserModel model)
        {
            user = new AppUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Username
            };

            IdentityResult result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "User");

                return user.Id;
            }

            throw new BadRequestException("User registration failed", result.Errors.ToDictionary(error => error.Code, error => new string[] { error.Description }));
        }

        public Task<string> CreateRefreshToken()
        {
            return jwtManager.CreateRefreshToken(user);
        }

        public async Task<TokenModel> VerifyRefreshToken(TokenModel request)
        {
            JwtSecurityTokenHandler securityToken = new JwtSecurityTokenHandler();

            JwtSecurityToken tokenContent = securityToken.ReadJwtToken(request.Token);

            string username = tokenContent.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Email)?.Value;
            string userid = tokenContent.Claims.FirstOrDefault(x => x.Type == "uid")?.Value;

            user = await userManager.FindByIdAsync(userid);

            if (user == null || user.Id != userid)
            {
                throw new UnauthorizedException();
            }

            bool isValidRefreshToken = await userManager.VerifyUserTokenAsync(user, identityTokenSettings.TokenProviderName, identityTokenSettings.TokenPurpose, request.RefreshToken);

            if (!isValidRefreshToken)
            {
                await userManager.UpdateSecurityStampAsync(user);
            }

            string token = await jwtManager.GenerateTokenAsync(user);
            string refreshToken = await jwtManager.CreateRefreshToken(user);

            TokenModel result = new TokenModel
            {
                Token = token,
                RefreshToken = refreshToken,
                UserId = user.Id
            };

            return result;
        }
    }
}
