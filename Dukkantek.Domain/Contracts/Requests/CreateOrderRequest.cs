using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dukkantek.Domain.Contracts.Requests
{
    public class CreateOrderRequest
    {
        public DateTime DateOfOrder { get; set; }
        public string Notes { get; set; }

        [InverseProperty(nameof(Models.OrderDetail.Order))]
        public ICollection<CreateOrderDetailRequest> OrderDetails { get; set; }
            = new List<CreateOrderDetailRequest>();

    }
}
