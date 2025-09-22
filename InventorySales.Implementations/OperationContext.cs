using InventorySales.Contracts;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.Security.Claims;

namespace InventorySales.Implementations
{
    public class OperationContext : IOperationContext
    {
        /// <summary>
        /// Each operation has a unique operation ID, which can be obtained by getting this property.
        /// </summary>
        private readonly Guid _OperationId;

        private readonly IHttpContextAccessor httpContextAccessor;

        public OperationContext(IHttpContextAccessor httpContextAccessor)
        {
            _OperationId = Guid.NewGuid();
            this.httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<string> Roles
        {
            get { return httpContextAccessor.HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value); }
        }

        public Guid UserId
        {
            get
            {
                Claim value = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "uid");
                if (value != null)
                {
                    return Guid.Parse(value.Value);
                }

                return Guid.Empty;
            }
        }

        public Guid OperationId
        {
            get
            {
                return _OperationId;
            }
        }
    }
}
