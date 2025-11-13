using AutoMapper;
using InventorySales.Api.DTO.ElementValue.Models;
using EntityModels = InventorySales.EntityFramework.Metadata;
namespace InventorySales.Api.DTO.ElementValue.Responses
{
    public class GetAllElementValuesByElementDefinitionIdResponse
    {
        public GetAllElementValuesByElementDefinitionIdResponse(IMapper mapper, IEnumerable<EntityModels.ElementValue> source)
        {
            Data = mapper.Map<IEnumerable<DTOElementValueModel>>(source);
        }
        public IEnumerable<DTOElementValueModel> Data { get; set; }
    }
}
