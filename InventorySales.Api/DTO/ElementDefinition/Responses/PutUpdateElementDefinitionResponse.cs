using AutoMapper;
using InventorySales.Api.DTO.ElementDefinition.Models;
using EntityModels = InventorySales.EntityFramework.Metadata;
namespace InventorySales.Api.DTO.ElementDefinition.Responses
{
    public class PutUpdateElementDefinitionResponse
    {
        public PutUpdateElementDefinitionResponse(IMapper mapper, EntityModels.ElementDefinition source)
        {
            Data = mapper.Map<DTOElementDefinitionModel>(source);
        }
        public DTOElementDefinitionModel Data { get; set; }
    }
}
