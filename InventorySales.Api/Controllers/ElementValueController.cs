using AutoMapper;
using InventorySales.Api.Attributes;
using InventorySales.Api.DTO.ElementValue.Requests;
using InventorySales.Api.DTO.ElementValue.Responses;
using InventorySales.Contracts.ElementValueServices;
using InventorySales.EntityFramework.Metadata;
using InventorySales.Models.ElementValue;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InventorySales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElementValueController : ControllerBase
    {
        private readonly IElementValueEntryService entryService;
        private readonly IElementValueDataService dataService;
        private readonly IMapper mapper;

        public ElementValueController(IElementValueEntryService entryService, IElementValueDataService dataService, IMapper mapper)
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
        public async Task<PostCreateElementValueResponse> CreateElementValue([FromBody] PostCreateElementValueRequest request)
        {
            ElementValue result = await entryService.CreateAsync(mapper.Map<ElementValueEntryModel>(request));

            return new PostCreateElementValueResponse(mapper, result);
        }

        [HttpPut("update/{id}")]
        [Authorize]
        [ApiResponseDocumentation(
            HttpStatusCode.BadRequest,
            HttpStatusCode.NotFound,
            HttpStatusCode.Unauthorized,
            HttpStatusCode.InternalServerError)]
        public async Task<PutUpdateElementValueResponse> UpdateElementValue([FromRoute] int id, [FromBody] PutUpdateElementValueRequest request)
        {
            ElementValue result = await entryService.UpdateAsync(id, mapper.Map<ElementValueEntryModel>(request));

            return new PutUpdateElementValueResponse(mapper, result);
        }

        [HttpDelete("delete/{id}")]
        [Authorize]
        [ApiResponseDocumentation(
            HttpStatusCode.NotFound,
            HttpStatusCode.Unauthorized,
            HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> DeleteElementValue([FromRoute] int id)
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
        public async Task<GetElementValueByIdResponse> GetElementValueById([FromRoute] int id)
        {
            ElementValue result = await dataService.GetByIdAsync(id);

            return new GetElementValueByIdResponse(mapper, result);
        }

        [HttpGet("get-all/{elementDefinitionId}")]
        [Authorize]
        [ApiResponseDocumentation(        
        HttpStatusCode.Unauthorized,
        HttpStatusCode.InternalServerError)]
        public async Task<GetAllElementValuesByElementDefinitionIdResponse> GetAllElementValuesByElementDefinitionId([FromRoute] int elementDefinitionId)
        {
            IEnumerable<ElementValue> result = await dataService.GetAllElementValuesByElementDefinitionIdAsync(elementDefinitionId);

            return new GetAllElementValuesByElementDefinitionIdResponse(mapper, result);
        }
    }
}
