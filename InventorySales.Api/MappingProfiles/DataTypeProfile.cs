using AutoMapper;
using InventorySales.Api.DTO.DataType.Models;
using InventorySales.Api.DTO.DataType.Requests;
using InventorySales.EntityFramework.Metadata;
using InventorySales.Models.DataType;
namespace InventorySales.Api.MappingProfiles
{
    public class DataTypeProfile : Profile
    {
        public DataTypeProfile()
        {
            CreateMap<PostCreateDataTypeRequest, DataTypeEntryModel>().ReverseMap();
            CreateMap<PutUpdateDataTypeRequest, DataTypeEntryModel>().ReverseMap();
            CreateMap<DataType, DTODataTypeModel>().ReverseMap();
        }
    }
}
