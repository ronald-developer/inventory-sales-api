using AutoMapper;
using InventorySales.Api.DTO.DataType.Models;
using EntityModels = InventorySales.EntityFramework.Metadata;
namespace InventorySales.Api.DTO.DataType.Responses
{
    public class GetAllDataTypesResponse
    {
        public GetAllDataTypesResponse(IMapper mapper, IEnumerable<EntityModels.DataType> source)
        {
            Data = mapper.Map<IEnumerable<DTODataTypeModel>>(source);
        }
        public IEnumerable<DTODataTypeModel> Data { get; set; }
    }
}
