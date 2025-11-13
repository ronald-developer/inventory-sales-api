using AutoMapper;
using InventorySales.Api.DTO.ElementValue.Models;
using EntityModels = InventorySales.EntityFramework.Metadata;
namespace InventorySales.Api.DTO.ElementValue.Responses
{
    public class PutUpdateElementValueResponse
    {
        public PutUpdateElementValueResponse(IMapper mapper, EntityModels.ElementValue source)
        {
            Data = mapper.Map<DTOElementValueModel>(source);
        }
        public DTOElementValueModel Data { get; set; }
    }
}
