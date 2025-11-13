using AutoMapper;
using InventorySales.Api.DTO.MetadataSchemaVersion.Models;
using InventorySales.Api.DTO.MetadataSchemaVersion.Requests;
using InventorySales.EntityFramework.Core;
using InventorySales.EntityFramework.Metadata;
using InventorySales.Models.MetadataSchemaVersion;

namespace InventorySales.Api.MappingProfiles
{
    public class MetadataSchemaVersionProfile : Profile
    {
        public MetadataSchemaVersionProfile()
        {
            CreateMap<PostCreateMetadataSchemaVersionRequest, MetadataSchemaVersionEntryModel>().ReverseMap();
            CreateMap<PutUpdateMetadataSchemaVersionRequest, MetadataSchemaVersionEntryModel>().ReverseMap();
            CreateMap<MetadataSchemaVersion, DTOMetadataSchemaVersionModel>().ReverseMap();
        }
    }
}
