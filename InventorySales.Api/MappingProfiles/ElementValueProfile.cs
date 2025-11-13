using AutoMapper;
using InventorySales.Api.DTO.ElementValue.Models;
using InventorySales.Api.DTO.ElementValue.Requests;
using InventorySales.EntityFramework.Metadata;
using InventorySales.Models.ElementValue;
namespace InventorySales.Api.MappingProfiles
{
    public class ElementValueProfile : Profile
    {
        public ElementValueProfile()
        {
            CreateMap<PostCreateElementValueRequest, ElementValueEntryModel>().ReverseMap();
            CreateMap<PutUpdateElementValueRequest, ElementValueEntryModel>().ReverseMap();
            CreateMap<ElementValue, DTOElementValueModel>().ReverseMap();
        }
    }
}
