using AutoMapper;
using InventorySales.Api.Attributes;
using InventorySales.Api.DTO.DataType.Requests;
using InventorySales.Api.DTO.DataType.Responses;
using InventorySales.Contracts.DataTypeServices;
using InventorySales.EntityFramework.Core;
using InventorySales.EntityFramework.Metadata;
using InventorySales.Models.DataType;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InventorySales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataTypeController : ControllerBase
    {
        private readonly IDataTypeEntryService entryService;
        private readonly IDataTypeDataService dataService;
        private readonly IMapper mapper;

        public DataTypeController(IDataTypeEntryService entryService, IDataTypeDataService dataService, IMapper mapper)
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
        public async Task<PostCreateDataTypeResponse> CreateDataType([FromBody] PostCreateDataTypeRequest request)
        {
            DataType result = await entryService.CreateAsync(mapper.Map<DataTypeEntryModel>(request));

            return new PostCreateDataTypeResponse(mapper, result);
        }

        [HttpPut("update/{id}")]
        [Authorize]
        [ApiResponseDocumentation(
            HttpStatusCode.BadRequest,
            HttpStatusCode.NotFound,
            HttpStatusCode.Unauthorized,
            HttpStatusCode.InternalServerError)]
        public async Task<PutUpdateDataTypeResponse> UpdateDataType([FromRoute] int id, [FromBody] PutUpdateDataTypeRequest request)
        {
            DataType result = await entryService.UpdateAsync(id, mapper.Map<DataTypeEntryModel>(request));

            return new PutUpdateDataTypeResponse(mapper, result);
        }

        [HttpDelete("delete/{id}")]
        [Authorize]
        [ApiResponseDocumentation(
            HttpStatusCode.NotFound,
            HttpStatusCode.Unauthorized,
            HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> DeleteDataType([FromRoute] int id)
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
        public async Task<GetDataTypeByIdResponse> GetDataTypeById([FromRoute] int id)
        {
            DataType result = await dataService.GetByIdAsync(id);

            return new GetDataTypeByIdResponse(mapper, result);
        }

        [HttpGet("get-all")]
        [Authorize]
        [ApiResponseDocumentation(
        HttpStatusCode.NotFound,
        HttpStatusCode.Unauthorized,
        HttpStatusCode.InternalServerError)]
        public async Task<GetAllDataTypesResponse> GetDataTypeById()
        {
            IEnumerable<DataType> result = await dataService.GetAllAsync();

            return new GetAllDataTypesResponse(mapper, result);
        }
    }
}
