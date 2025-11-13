using System.ComponentModel.DataAnnotations;

namespace InventorySales.Api.DTO.AssetType.Requests
{
    public class PostCreateAssetTypeRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
