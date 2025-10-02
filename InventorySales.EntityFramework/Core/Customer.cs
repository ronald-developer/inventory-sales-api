using InventorySales.EntityFramework.Transaction;

namespace InventorySales.EntityFramework.Core
{
    /// <summary>
    /// Represents a customer who can purchase assets.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Primary key.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// First name of the customer.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the customer.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Email address of the customer.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Phone number of the customer.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Address of the customer.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Collection of sales associated with this customer.
        /// </summary>
        public ICollection<Sale> Sales { get; set; }
    }
}
