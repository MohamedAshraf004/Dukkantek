using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dukkantek.Domain.Models.Enums;

namespace Dukkantek.Domain.Models
{
    public class Product : BaseEntity
    {
        [Required,MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string BarCode { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public double Weight { get; set; }
        public ProductStatus ProductStatus { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        [InverseProperty(nameof(Models.ProductCategory.Products))]
        public ProductCategory ProductCategory { get; set; }

        [InverseProperty(nameof(Models.OrderDetail.Product))]
        public ICollection<OrderDetail> OrderDetails { get; set; }
            = new List<OrderDetail>();

    }
}
