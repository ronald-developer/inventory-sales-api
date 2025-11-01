using System.ComponentModel.DataAnnotations;

namespace InventorySales.Api.DTO.Account.Requests
{
    public class PostLoginRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Your password is limited to {2} to {1} characters", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
