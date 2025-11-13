using AutoMapper;
using InventorySales.Api.Attributes;
using InventorySales.Api.DTO.AssetType.Requests;
using InventorySales.Api.DTO.AssetType.Responses;
using InventorySales.Contracts.AssetTypeServices;
using InventorySales.EntityFramework.Core;
using InventorySales.Models.AssetType;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InventorySales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetTypeController : ControllerBase
    {
        private readonly IAssetTypeEntryService entryService;
        private readonly IAssetTypeDataService dataService;
        private readonly IMapper mapper;

        public AssetTypeController(IAssetTypeEntryService entryService, IAssetTypeDataService dataService, IMapper mapper)
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
        public async Task<PostCreateAssetTypeResponse> CreateAssetType([FromBody] PostCreateAssetTypeRequest request)
        {
            AssetType result = await entryService.CreateAsync(mapper.Map<AssetTypeEntryModel>(request));

            return new PostCreateAssetTypeResponse(mapper, result);
        }

        [HttpPut("update/{id}")]
        [Authorize]
        [ApiResponseDocumentation(
            HttpStatusCode.BadRequest,
            HttpStatusCode.NotFound,
            HttpStatusCode.Unauthorized,
            HttpStatusCode.InternalServerError)]
        public async Task<PutUpdateAssetTypeResponse> UpdateAssetType([FromRoute] int id, [FromBody] PutUpdateAssetTypeRequest request)
        {
            AssetType result = await entryService.UpdateAsync(id, mapper.Map<AssetTypeEntryModel>(request));

            return new PutUpdateAssetTypeResponse(mapper, result);
        }

        [HttpDelete("delete/{id}")]
        [Authorize]
        [ApiResponseDocumentation(
            HttpStatusCode.NotFound,
            HttpStatusCode.Unauthorized,
            HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> DeleteAssetType([FromRoute] int id)
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
        public async Task<GetAssetTypeByIdResponse> GetAssetTypeById([FromRoute] int id)
        {
            AssetType result = await dataService.GetByIdAsync(id);

            return new GetAssetTypeByIdResponse(mapper, result);
        }

        [HttpGet("get-all")]
        [Authorize]
        [ApiResponseDocumentation(
        HttpStatusCode.NotFound,
        HttpStatusCode.Unauthorized,
        HttpStatusCode.InternalServerError)]
        public async Task<GetAllAssetTypesResponse> GetAssetTypeById()
        {
            IEnumerable<AssetType> result = await dataService.GetAllAsync();

            return new GetAllAssetTypesResponse(mapper, result);
        }
    }
}
