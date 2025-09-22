using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySales.Models.AccountManager
{
    public class LoginModel
    {
        /// <summary>
        /// Either Username or Email can be used to login
        /// </summary>
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
