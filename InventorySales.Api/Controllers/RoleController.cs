using AutoMapper;
using Azure.Core;
using InventorySales.Api.Attributes;
using InventorySales.Api.DTO.AccountManager.Requests;
using InventorySales.Api.DTO.AccountManager.Responses;
using InventorySales.Api.DTO.RoleManager.Requests;
using InventorySales.Api.DTO.RoleManager.Responses;
using InventorySales.Contracts;
using InventorySales.EntityFramework;
using InventorySales.Implementations;
using InventorySales.Models.AccountManager;
using InventorySales.Models.RoleManager;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InventorySales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleManagerService roleManagerService;
        private readonly IMapper mapper;

        public RoleController(IRoleManagerService roleManagerService, IMapper mapper)
        {
            this.roleManagerService = roleManagerService;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("create")]
        [ApiResponseDocumentation(
            HttpStatusCode.Unauthorized,
            HttpStatusCode.InternalServerError)]
        public async Task<PostCreateRoleResponse> CreateRole([FromBody] PostCreateRoleRequest request)
        {
            AppRole response = await roleManagerService.CreateRole(mapper.Map<RoleModel>(request));

            return new PostCreateRoleResponse(mapper, response);
        }

        // PUT api/roles
        [HttpPut]
        [Route("update/{id}")]
        [ApiResponseDocumentation(
            HttpStatusCode.BadRequest,
            HttpStatusCode.NotFound,
            HttpStatusCode.Unauthorized,
            HttpStatusCode.InternalServerError)]
        public async Task<PostUpdateRoleResponse> UpdateRole([FromRoute] Guid id, [FromBody] PostCreateRoleRequest request)
        {

            AppRole response = await roleManagerService.UpdateRole(id, mapper.Map<RoleModel>(request));

            return new PostUpdateRoleResponse(mapper, response);
        }

        // DELETE api/roles/{id}
        [HttpDelete]
        [Route("update/{id}")]
        [ApiResponseDocumentation(
            HttpStatusCode.NotFound,
            HttpStatusCode.Unauthorized,
            HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> DeleteRole([FromRoute] Guid id)
        {
            await roleManagerService.DeleteRole(id);
            return Ok();
        }


    }
}
