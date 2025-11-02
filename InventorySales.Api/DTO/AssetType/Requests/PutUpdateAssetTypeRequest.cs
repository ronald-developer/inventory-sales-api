using System.ComponentModel.DataAnnotations;

namespace InventorySales.Api.DTO.AssetType.Requests
{
    public class PutUpdateAssetTypeRequest {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
