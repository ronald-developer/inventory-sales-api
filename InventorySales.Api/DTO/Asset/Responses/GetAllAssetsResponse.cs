using AutoMapper;
using InventorySales.Api.DTO.Asset.Models;
using EntityModels = InventorySales.EntityFramework.Core;
namespace InventorySales.Api.DTO.Asset.Responses
{
    public class GetAllAssetsResponse
    {
        public GetAllAssetsResponse(IMapper mapper, IEnumerable<EntityModels.Asset> source)
        {
            Data = mapper.Map<IEnumerable<DTOAssetModel>>(source);
        }
        public IEnumerable<DTOAssetModel> Data { get; set; }
    }

}
