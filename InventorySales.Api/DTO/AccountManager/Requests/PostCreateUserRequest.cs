using System.ComponentModel.DataAnnotations;

namespace InventorySales.Api.DTO.AccountManager.Requests
{
    public class PostCreateUserRequest : PostLoginRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
