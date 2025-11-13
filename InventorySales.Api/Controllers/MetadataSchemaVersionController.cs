using AutoMapper;
using InventorySales.Api.Attributes;
using InventorySales.Api.DTO.MetadataSchemaVersion.Requests;
using InventorySales.Api.DTO.MetadataSchemaVersion.Responses;
using InventorySales.Contracts.MetadataSchemaVersionServices;
using InventorySales.EntityFramework.Core;
using InventorySales.EntityFramework.Metadata;
using InventorySales.Models.MetadataSchemaVersion;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InventorySales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetadataSchemaVersionController : ControllerBase
    {
        private readonly IMetadataSchemaVersionEntryService entryService;
        private readonly IMetadataSchemaVersionDataService dataService;
        private readonly IMapper mapper;

        public MetadataSchemaVersionController(IMetadataSchemaVersionEntryService entryService, IMetadataSchemaVersionDataService dataService, IMapper mapper)
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
        public async Task<PostCreateMetadataSchemaVersionResponse> CreateMetadataSchemaVersion([FromBody] PostCreateMetadataSchemaVersionRequest request)
        {
            MetadataSchemaVersion result = await entryService.CreateAsync(mapper.Map<MetadataSchemaVersionEntryModel>(request));

            return new PostCreateMetadataSchemaVersionResponse(mapper, result);
        }

        [HttpPut("update/{id}")]
        [Authorize]
        [ApiResponseDocumentation(
            HttpStatusCode.BadRequest,
            HttpStatusCode.NotFound,
            HttpStatusCode.Unauthorized,
            HttpStatusCode.InternalServerError)]
        public async Task<PutUpdateMetadataSchemaVersionResponse> UpdateMetadataSchemaVersion([FromRoute] int id, [FromBody] PutUpdateMetadataSchemaVersionRequest request)
        {
            MetadataSchemaVersion result = await entryService.UpdateAsync(id, mapper.Map<MetadataSchemaVersionEntryModel>(request));

            return new PutUpdateMetadataSchemaVersionResponse(mapper, result);
        }

        [HttpDelete("delete/{id}")]
        [Authorize]
        [ApiResponseDocumentation(
            HttpStatusCode.NotFound,
            HttpStatusCode.Unauthorized,
            HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> DeleteMetadataSchemaVersion([FromRoute] int id)
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
        public async Task<GetMetadataSchemaVersionByIdResponse> GetMetadataSchemaVersionById([FromRoute] int id)
        {
            MetadataSchemaVersion result = await dataService.GetByIdAsync(id);

            return new GetMetadataSchemaVersionByIdResponse(mapper, result);
        }

        [HttpGet("get-all")]
        [Authorize]
        [ApiResponseDocumentation(
        HttpStatusCode.NotFound,
        HttpStatusCode.Unauthorized,
        HttpStatusCode.InternalServerError)]
        public async Task<GetAllMetadataSchemaVersionsResponse> GetMetadataSchemaVersionById()
        {
            IEnumerable<MetadataSchemaVersion> result = await dataService.GetAllAsync();

            return new GetAllMetadataSchemaVersionsResponse(mapper, result);
        }
    }
}
