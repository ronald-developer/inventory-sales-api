using System.ComponentModel.DataAnnotations;

namespace InventorySales.EntityFramework
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
