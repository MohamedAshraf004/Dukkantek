using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Domain.Models
{
    public class Order : BaseEntity
    {
        public DateTime DateOfOrder { get; set; }
        public string Notes { get; set; }
        [InverseProperty(nameof(Models.OrderDetail.Order))]
        public ICollection<OrderDetail> OrderDetails { get; set; }
            = new List<OrderDetail>();
        //User && Discounts !!
    }
}
