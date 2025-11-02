using AutoMapper;
using InventorySales.Api.DTO.AssetType.Models;
using EntityModels = InventorySales.EntityFramework.Core;
namespace InventorySales.Api.DTO.AssetType.Responses
{
    public class GetAllAssetTypesResponse
    {
        public GetAllAssetTypesResponse(IMapper mapper, IEnumerable<EntityModels.AssetType> source)
        {
            Data = mapper.Map<IEnumerable<DTOAssetTypeModel>>(source);
        }
        public IEnumerable<DTOAssetTypeModel> Data { get; set; }
    }
}
