using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dukkantek.Domain.Models
{
    public class ProductCategory : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [InverseProperty(nameof(Product.ProductCategory))]
        public ICollection<Product> Products { get; set; }
            = new HashSet<Product>();
    }
}