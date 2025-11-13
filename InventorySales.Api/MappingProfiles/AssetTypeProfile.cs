using AutoMapper;
using InventorySales.Api.DTO.AssetType.Models;
using InventorySales.Api.DTO.AssetType.Requests;
using InventorySales.EntityFramework.Core;
using InventorySales.Models.AssetType;

namespace InventorySales.Api.MappingProfiles
{
    public class AssetTypeProfile : Profile
    {
        public AssetTypeProfile()
        {
            CreateMap<PostCreateAssetTypeRequest, AssetTypeEntryModel>().ReverseMap();
            CreateMap<PutUpdateAssetTypeRequest, AssetTypeEntryModel>().ReverseMap();
            CreateMap<AssetType, DTOAssetTypeModel>().ReverseMap();
        }
    }
}
