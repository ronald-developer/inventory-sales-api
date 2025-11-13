using AutoMapper;
using InventorySales.Api.Attributes;
using InventorySales.Api.DTO.ElementDefinition.Requests;
using InventorySales.Api.DTO.ElementDefinition.Responses;
using InventorySales.Contracts.ElementDefinitionServices;
using InventorySales.EntityFramework.Core;
using InventorySales.EntityFramework.Metadata;
using InventorySales.Models.ElementDefinition;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InventorySales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElementDefinitionController : ControllerBase
    {
        private readonly IElementDefinitionEntryService entryService;
        private readonly IElementDefinitionDataService dataService;
        private readonly IMapper mapper;

        public ElementDefinitionController(IElementDefinitionEntryService entryService, IElementDefinitionDataService dataService, IMapper mapper)
        {
            this.entryService = entryService;
            this.dataService = dataService;
            this.mapper = mapper;
        }

        [HttpPost("create")]
        [Authorize]
        [ApiResponseDocumentation(
                HttpStatusCode.Unauthorized,
                HttpStatusCode.InternalServerError)]
        public async Task<PostCreateElementDefinitionResponse> CreateElementDefinition([FromBody] PostCreateElementDefinitionRequest request)
        {
            ElementDefinition result = await entryService.CreateAsync(mapper.Map<ElementDefinitionEntryModel>(request));

            return new PostCreateElementDefinitionResponse(mapper, result);
        }

        [HttpPut("update/{id}")]
        [Authorize]
        [ApiResponseDocumentation(
            HttpStatusCode.BadRequest,
            HttpStatusCode.NotFound,
            HttpStatusCode.Unauthorized,
            HttpStatusCode.InternalServerError)]
        public async Task<PutUpdateElementDefinitionResponse> UpdateElementDefinition([FromRoute] int id, [FromBody] PutUpdateElementDefinitionRequest request)
        {
            ElementDefinition result = await entryService.UpdateAsync(id, mapper.Map<ElementDefinitionEntryModel>(request));

            return new PutUpdateElementDefinitionResponse(mapper, result);
        }

        [HttpDelete("delete/{id}")]
        [Authorize]
        [ApiResponseDocumentation(
            HttpStatusCode.NotFound,
            HttpStatusCode.Unauthorized,
            HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> DeleteElementDefinition([FromRoute] int id)
        {
            await entryService.DeleteAsync(id);

            return Ok();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        [ApiResponseDocumentation(
        HttpStatusCode.NotFound,
        HttpStatusCode.Unauthorized,
        HttpStatusCode.InternalServerError)]
        public async Task<GetElementDefinitionByIdResponse> GetElementDefinitionById([FromRoute] int id)
        {
            ElementDefinition result = await dataService.GetByIdAsync(id);

            return new GetElementDefinitionByIdResponse(mapper, result);
        }

        [HttpGet("get-all")]
        [Authorize]
        [ApiResponseDocumentation(
        HttpStatusCode.NotFound,
        HttpStatusCode.Unauthorized,
        HttpStatusCode.InternalServerError)]
        public async Task<GetAllElementDefinitionsResponse> GetElementDefinitionById()
        {
            IEnumerable<ElementDefinition> result = await dataService.GetAllAsync();

            return new GetAllElementDefinitionsResponse(mapper, result);
        }
    }
}
