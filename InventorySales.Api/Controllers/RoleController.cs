using AutoMapper;
using InventorySales.Api.Attributes;
using InventorySales.Api.DTO.Role.Requests;
using InventorySales.Api.DTO.Role.Responses;
using InventorySales.Contracts;
using InventorySales.EntityFramework;
using InventorySales.Models.RoleManager;
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
        [Authorize]
        [ApiResponseDocumentation(
            HttpStatusCode.Unauthorized,
            HttpStatusCode.InternalServerError)]
        public async Task<PostCreateRoleResponse> CreateRole([FromBody] PostCreateRoleRequest request)
        {
            AppRole response = await roleManagerService.Create(mapper.Map<RoleModel>(request));

            return new PostCreateRoleResponse(mapper, response);
        }

        // PUT api/roles
        [HttpPut]
        [Route("update/{id}")]
        [Authorize]
        [ApiResponseDocumentation(
            HttpStatusCode.BadRequest,
            HttpStatusCode.NotFound,
            HttpStatusCode.Unauthorized,
            HttpStatusCode.InternalServerError)]
        public async Task<PostUpdateRoleResponse> UpdateRole([FromRoute] Guid id, [FromBody] PostCreateRoleRequest request)
        {

            AppRole response = await roleManagerService.Update(id, mapper.Map<RoleModel>(request));

            return new PostUpdateRoleResponse(mapper, response);
        }

        // DELETE api/roles/{id}
        [HttpDelete]
        [Route("update/{id}")]
        [Authorize]
        [ApiResponseDocumentation(
            HttpStatusCode.NotFound,
            HttpStatusCode.Unauthorized,
            HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> DeleteRole([FromRoute] Guid id)
        {
            await roleManagerService.Delete(id);
            return Ok();
        }


    }
}
