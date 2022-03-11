using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dukkantek.Domain.Models
{
    public class OrderDetail : BaseEntity
    {
       
        public double Amount { get; set; }
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty(nameof(Models.Order.OrderDetails))]
        public Order Order { get; set; }
        [InverseProperty(nameof(OrderDetailsInvtProduct.OrderDetail))]
        public ICollection<OrderDetailsInvtProduct> OrderDetailsInvtProducts { get; set; }
            = new List<OrderDetailsInvtProduct>();


    }
}