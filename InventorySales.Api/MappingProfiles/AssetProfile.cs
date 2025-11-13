using AutoMapper;
using InventorySales.Api.DTO.Asset.Models;
using InventorySales.EntityFramework.Core;
using InventorySales.Models.Asset;
using InventorySales.Api.DTO.Asset.Requests;
namespace InventorySales.Api.MappingProfiles
{
    public class AssetProfile : Profile
    {
        public AssetProfile()
        {
            CreateMap<PostCreateAssetRequest, AssetEntryModel>().ReverseMap();
            CreateMap<PutUpdateAssetRequest, AssetEntryModel>().ReverseMap();
            CreateMap<Asset, DTOAssetModel>().ReverseMap();
        }
    }
}
