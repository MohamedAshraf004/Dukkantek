using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dukkantek.Domain.Models
{
    public class OrderDetail : BaseEntity
    {
       
        public double Amount { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty(nameof(Models.Order.OrderDetails))]
        public Order Order { get; set; }


        [ForeignKey(nameof(ProductId))]
        [InverseProperty(nameof(Models.Product.OrderDetails))]
        public Product Product { get; set; }

    }
}