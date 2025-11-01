using AutoMapper;
using InventorySales.Api.DTO.AssetType.Models;
using EntityModels = InventorySales.EntityFramework.Core;
namespace InventorySales.Api.DTO.AssetType.Responses
{
    public class PostCreateAssetTypeResponse
    {

        public PostCreateAssetTypeResponse(IMapper mapper, EntityModels.AssetType source)
        {
            Data = mapper.Map<DTOAssetTypeModel>(source);
        }
        public DTOAssetTypeModel Data { get; set; }
    }
}
