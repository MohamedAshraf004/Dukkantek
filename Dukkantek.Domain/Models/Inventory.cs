using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dukkantek.Domain.Models
{
    public class Inventory : BaseEntity
    {
        [Required,MaxLength(250)]
        public string Name { get; set; }

        [InverseProperty(nameof(Models.InventoryProduct.Inventory))]
        public ICollection<InventoryProduct> InventoryProducts { get; set; }
            = new HashSet<InventoryProduct>();
    }
}
