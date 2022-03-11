using System.ComponentModel.DataAnnotations.Schema;

namespace Dukkantek.Domain.Models
{
    public class InventoryProduct   : BaseEntity
    {
        public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }

        [InverseProperty(nameof(Models.Product.ProductInventories))]
        public Product Product { get; set; }

        [InverseProperty(nameof(Models.Inventory.InventoryProducts))]
        public Inventory Inventory { get; set; }

    }
}