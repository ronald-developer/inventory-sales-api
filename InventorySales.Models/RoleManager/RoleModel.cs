using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySales.Models.RoleManager
{
    public class RoleModel
    {        
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
