using AutoMapper;
using InventorySales.Api.DTO.DataType.Models;
using EntityModels = InventorySales.EntityFramework.Metadata;
namespace InventorySales.Api.DTO.DataType.Responses
{
    public class PostCreateDataTypeResponse
    {
        public PostCreateDataTypeResponse(IMapper mapper, EntityModels.DataType source)
        {
            Data = mapper.Map<DTODataTypeModel>(source);
        }
        public DTODataTypeModel Data { get; set; }
    }
}
