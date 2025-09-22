namespace InventorySales.Models.AccountManager
{
    public class UserModel : LoginModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
