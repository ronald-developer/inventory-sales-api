using InventorySales.EntityFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySales.EntityFramework.Transaction
{
    /// <summary>
    /// Represents a completed sale transaction between a customer and an asset.
    /// </summary>
    public class Sale
    {
        /// <summary>
        /// Primary key.
        /// </summary>
        public int SaleId { get; set; }

        /// <summary>
        /// Foreign key to the asset being sold.
        /// </summary>
        public int AssetId { get; set; }

        /// <summary>
        /// Foreign key to the customer who bought the asset.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Date the sale occurred.
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// Final sale price.
        /// </summary>
        public decimal SalePrice { get; set; }

        /// <summary>
        /// Payment method used (e.g., Cash, Card, Finance).
        /// </summary>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// Navigation property to the sold asset.
        /// </summary>
        public Asset Asset { get; set; }

        /// <summary>
        /// Navigation property to the customer who made the purchase.
        /// </summary>
        public Customer Customer { get; set; }
    }
}
