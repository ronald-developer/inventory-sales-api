using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySales.Models.Authorization
{
    public class MinimumRolesAuthorizationRequirement : IAuthorizationRequirement
    {
        public IEnumerable<string> MinimumAllowedRoles { get; }
        public MinimumRolesAuthorizationRequirement(string minimumRoles = null)
        {
            List<string> roles = new List<string>();

            if (!string.IsNullOrEmpty(minimumRoles))
            {
                roles.AddRange(minimumRoles.Split(","));
            }

            this.MinimumAllowedRoles = roles;
        }
    }
}
