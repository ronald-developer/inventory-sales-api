using AutoMapper;
using InventorySales.Api.Attributes;
using InventorySales.Api.DTO.AccountManager.Requests;
using InventorySales.Api.DTO.AccountManager.Responses;
using InventorySales.Contracts;
using InventorySales.Models.AccountManager;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InventorySales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountManagerService accountManagerService;
        private readonly IMapper mapper;

        public AccountController(IAccountManagerService accountManagerService, IMapper mapper)
        {
            this.accountManagerService = accountManagerService;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        [ApiResponseDocumentation(
            HttpStatusCode.Unauthorized, 
            HttpStatusCode.InternalServerError)]
        public async Task<PostLoginResponse> Login([FromBody] PostLoginRequest request)
        {
            TokenModel response = await accountManagerService.Login(mapper.Map<LoginModel>(request));

            return new PostLoginResponse(mapper, response);
        }

        [HttpPost]
        [Route("register")]
        [ApiResponseDocumentation(
            HttpStatusCode.Unauthorized,
            HttpStatusCode.InternalServerError)]
        public async Task<PostCreateUserResponse> Register([FromBody] PostCreateUserRequest request)
        {
            string registeredUserId = await accountManagerService.Register(mapper.Map<UserModel>(request));

            return new PostCreateUserResponse(registeredUserId);
        }


        [HttpPost]
        [Route("refreshToken")]
        public async Task<PostRefreshTokenResponse> RefreshToken([FromBody] PostRefreshTokenRequest request)
        {
            TokenModel response = await accountManagerService.VerifyRefreshToken(mapper.Map<TokenModel>(request));

            return new PostRefreshTokenResponse(mapper, response);
        }
    }
}
