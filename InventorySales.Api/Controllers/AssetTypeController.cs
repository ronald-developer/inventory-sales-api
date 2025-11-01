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
        private readonly IAssetTypeEntryService assetTypeService;
        private readonly IAssetTypeDataService assetTypeDataService;
        private readonly IMapper mapper;

        public AssetTypeController(IAssetTypeEntryService assetTypeService, IAssetTypeDataService assetTypeDataService, IMapper mapper)
        {
            this.assetTypeService = assetTypeService;
            this.assetTypeDataService = assetTypeDataService;
            this.mapper = mapper;
        }

        [HttpPost("create")]
        [Authorize("Administrator")]
        [ApiResponseDocumentation(
                HttpStatusCode.Unauthorized,
                HttpStatusCode.InternalServerError)]
        public async Task<PostCreateAssetTypeResponse> CreateAssetType([FromBody] PostCreateAssetTypeRequest request)
        {
            AssetType result = await assetTypeService.CreateAsync(mapper.Map<AssetTypeEntryModel>(request));

            return new PostCreateAssetTypeResponse(mapper, result);
        }

        [HttpPut("update/{id}")]
        [Authorize]
        [ApiResponseDocumentation(
            HttpStatusCode.BadRequest,
            HttpStatusCode.NotFound,
            HttpStatusCode.Unauthorized,
            HttpStatusCode.InternalServerError)]
        public async Task<PostUpdateAssetTypeResponse> UpdateAssetType([FromRoute] int id, [FromBody] PutUpdateAssetTypeRequest request)
        {
            AssetType result = await assetTypeService.UpdateAsync(id, mapper.Map<AssetTypeEntryModel>(request));

            return new PostUpdateAssetTypeResponse(mapper, result);
        }

        [HttpDelete("delete/{id}")]
        [Authorize]
        [ApiResponseDocumentation(
            HttpStatusCode.NotFound,
            HttpStatusCode.Unauthorized,
            HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> DeleteAssetType([FromRoute] int id)
        {
            await assetTypeService.DeleteAsync(id);

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
            AssetType result = await assetTypeDataService.GetByIdAsync(id);

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
            IEnumerable<AssetType> result = await assetTypeDataService.GetAllAsync();

            return new GetAllAssetTypesResponse(mapper, result);
        }
    }
}
