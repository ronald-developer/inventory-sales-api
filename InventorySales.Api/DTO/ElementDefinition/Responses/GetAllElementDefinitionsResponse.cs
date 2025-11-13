using AutoMapper;
using InventorySales.Api.DTO.ElementDefinition.Models;
using EntityModels = InventorySales.EntityFramework.Metadata;

namespace InventorySales.Api.DTO.ElementDefinition.Responses
{
    public class GetAllElementDefinitionsResponse
    {
        public GetAllElementDefinitionsResponse(IMapper mapper, IEnumerable<EntityModels.ElementDefinition> source)
        {
            Data = mapper.Map<IEnumerable<DTOElementDefinitionModel>>(source);
        }
        public IEnumerable<DTOElementDefinitionModel> Data { get; set; }
    }
}
