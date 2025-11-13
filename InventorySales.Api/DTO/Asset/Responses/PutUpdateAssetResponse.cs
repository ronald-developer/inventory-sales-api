using AutoMapper;
using InventorySales.Api.DTO.Asset.Models;
using EntityModels = InventorySales.EntityFramework.Core;
namespace InventorySales.Api.DTO.Asset.Responses
{
    public class PutUpdateAssetResponse
    {
        public PutUpdateAssetResponse(IMapper mapper, EntityModels.Asset source)
        {
            Data = mapper.Map<DTOAssetModel>(source);
        }
        public DTOAssetModel Data { get; set; }
    }

}
