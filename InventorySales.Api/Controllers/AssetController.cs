using AutoMapper;
using InventorySales.Api.Attributes;
using InventorySales.Api.DTO.Asset.Requests;
using InventorySales.Api.DTO.Asset.Responses;
using InventorySales.Contracts.AssetServices;
using InventorySales.EntityFramework.Core;
using InventorySales.Models.Asset;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InventorySales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IAssetEntryService entryService;
        private readonly IAssetDataService dataService;
        private readonly IMapper mapper;

        public AssetController(IAssetEntryService entryService, IAssetDataService dataService, IMapper mapper)
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
        public async Task<PostCreateAssetResponse> CreateAsset([FromBody] PostCreateAssetRequest request)
        {
            Asset result = await entryService.CreateAsync(mapper.Map<AssetEntryModel>(request));

            return new PostCreateAssetResponse(mapper, result);
        }

        [HttpPut("update/{id}")]
        [Authorize]
        [ApiResponseDocumentation(
            HttpStatusCode.BadRequest,
            HttpStatusCode.NotFound,
            HttpStatusCode.Unauthorized,
            HttpStatusCode.InternalServerError)]
        public async Task<PutUpdateAssetResponse> UpdateAsset([FromRoute] int id, [FromBody] PutUpdateAssetRequest request)
        {
            Asset result = await entryService.UpdateAsync(id, mapper.Map<AssetEntryModel>(request));

            return new PutUpdateAssetResponse(mapper, result);
        }

        [HttpDelete("delete/{id}")]
        [Authorize]
        [ApiResponseDocumentation(
            HttpStatusCode.NotFound,
            HttpStatusCode.Unauthorized,
            HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> DeleteAsset([FromRoute] int id)
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
        public async Task<GetAssetByIdResponse> GetAssetById([FromRoute] int id)
        {
            Asset result = await dataService.GetByIdAsync(id);

            return new GetAssetByIdResponse(mapper, result);
        }

        [HttpGet("get-all")]
        [Authorize]
        [ApiResponseDocumentation(
        HttpStatusCode.NotFound,
        HttpStatusCode.Unauthorized,
        HttpStatusCode.InternalServerError)]
        public async Task<GetAllAssetsResponse> GetAssetById()
        {
            IEnumerable<Asset> result = await dataService.GetAllAsync();

            return new GetAllAssetsResponse(mapper, result);
        }
    }
}
