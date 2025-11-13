using AutoMapper;
using InventorySales.Api.DTO.ElementDefinition.Models;
using InventorySales.Api.DTO.ElementDefinition.Requests;
using InventorySales.EntityFramework.Metadata;
using InventorySales.Models.ElementDefinition;
namespace InventorySales.Api.MappingProfiles
{
    public class ElementDefinitionProfile : Profile
    {
        public ElementDefinitionProfile()
        {
            CreateMap<PostCreateElementDefinitionRequest, ElementDefinitionEntryModel>().ReverseMap();
            CreateMap<PutUpdateElementDefinitionRequest, ElementDefinitionEntryModel>().ReverseMap();
            CreateMap<ElementDefinition, DTOElementDefinitionModel>().ReverseMap();
        }
    }
}
