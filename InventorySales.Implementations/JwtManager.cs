using InventorySales.Contracts;
using InventorySales.EntityFramework;
using InventorySales.Models.AppSettings;
using InventorySales.Models.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InventorySales.Implementations
{
    public class JwtManager : IJwtManager
    {
        private readonly UserManager<AppUser> userManager;
        private readonly TokenValidationParameters tokenValidationParameters;
        private readonly JwtSettings jwtSettings;
        private readonly IConfiguration configuration;
        private readonly IdentityTokenSettings identityTokenSettings;

        public JwtManager(
            UserManager<AppUser> userManager,
            IOptions<JwtSettings> jwtSettings,
            IOptions<IdentityTokenSettings> identityTokenSettings,
            TokenValidationParameters tokenValidationParameters)
        {
            this.userManager = userManager;
            this.tokenValidationParameters = tokenValidationParameters;
            this.jwtSettings = jwtSettings.Value;
            this.identityTokenSettings = identityTokenSettings.Value;
        }

        public async Task<string> GenerateTokenAsync(AppUser user)
        {
            string token = string.Empty;

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));

            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            IList<string> roles = await userManager.GetRolesAsync(user);

            IEnumerable<Claim> roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role));

            IList<Claim> userClaims = await userManager.GetClaimsAsync(user);

            IEnumerable<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.System, ApplicationConstants.SystemName),
                new Claim("uid", user.Id),
            }.Union(userClaims).Union(roleClaims);

            JwtSecurityToken securityToken = new JwtSecurityToken(
                    issuer: "InventorySales",
                    audience: "InventorySalesClient",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(Convert.ToInt32(jwtSettings.DurationInMinutes)),
                    signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        public async Task<string> CreateRefreshToken(AppUser user)
        {
            await userManager.RemoveAuthenticationTokenAsync(user, identityTokenSettings.TokenProviderName, identityTokenSettings.TokenPurpose);
            string newToken = await userManager.GenerateUserTokenAsync(user, identityTokenSettings.TokenProviderName, identityTokenSettings.TokenPurpose);
            IdentityResult result = await userManager.SetAuthenticationTokenAsync(user, identityTokenSettings.TokenProviderName, identityTokenSettings.TokenPurpose, newToken);

            return newToken;
        }

        

        public  ClaimsPrincipal DecodeJwtToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            SecurityToken validatedToken;
            Console.WriteLine($"ValidIssuer: '{tokenValidationParameters.ValidIssuer}'");
            Console.WriteLine($"ValidAudience: '{tokenValidationParameters.ValidAudience}'");
            Console.WriteLine($"SigningKey length: {tokenValidationParameters.IssuerSigningKey?.KeySize}");
            return handler.ValidateToken(token, tokenValidationParameters, out validatedToken);
        }
    }
}