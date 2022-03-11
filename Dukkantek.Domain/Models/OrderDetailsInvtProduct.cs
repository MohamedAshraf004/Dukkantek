using System.ComponentModel.DataAnnotations.Schema;

namespace Dukkantek.Domain.Models
{
    public class OrderDetailsInvtProduct : BaseEntity
    {
        public double Amount { get; set; }

        public int ProductInventoryId { get; set; }
        [ForeignKey(nameof(ProductInventoryId))]
        [InverseProperty(nameof(Models.InventoryProduct.OrderDetailsInvtProducts))]
        public InventoryProduct ProductInventory { get; set; }

        public int OrderDetailId { get; set; }
        [ForeignKey(nameof(OrderDetailId))]
        [InverseProperty(nameof(Models.OrderDetail.OrderDetailsInvtProducts))]
        public OrderDetail OrderDetail { get; set; }
    }
}