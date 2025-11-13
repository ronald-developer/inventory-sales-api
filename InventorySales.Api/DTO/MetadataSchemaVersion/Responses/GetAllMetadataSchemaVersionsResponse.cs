using AutoMapper;
using InventorySales.Api.DTO.MetadataSchemaVersion.Models;
using EntityModels = InventorySales.EntityFramework.Metadata;

namespace InventorySales.Api.DTO.MetadataSchemaVersion.Responses
{
    public class GetAllMetadataSchemaVersionsResponse
    {
        public GetAllMetadataSchemaVersionsResponse(IMapper mapper, IEnumerable<EntityModels.MetadataSchemaVersion> source)
        {
            Data = mapper.Map<IEnumerable<DTOMetadataSchemaVersionModel>>(source);
        }
        public IEnumerable<DTOMetadataSchemaVersionModel> Data { get; set; }
    }
}
