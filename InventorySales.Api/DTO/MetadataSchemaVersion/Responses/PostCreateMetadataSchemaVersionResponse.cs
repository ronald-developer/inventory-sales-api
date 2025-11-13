using AutoMapper;
using InventorySales.Api.DTO.MetadataSchemaVersion.Models;
using EntityModels = InventorySales.EntityFramework.Metadata;

namespace InventorySales.Api.DTO.MetadataSchemaVersion.Responses
{
    public class PostCreateMetadataSchemaVersionResponse
    {
        public PostCreateMetadataSchemaVersionResponse(IMapper mapper, EntityModels.MetadataSchemaVersion source)
        {
            Data = mapper.Map<DTOMetadataSchemaVersionModel>(source);
        }
        public DTOMetadataSchemaVersionModel Data { get; set; }
    }
}
