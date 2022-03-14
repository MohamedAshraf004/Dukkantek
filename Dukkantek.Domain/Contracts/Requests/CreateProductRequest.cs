using System.ComponentModel.DataAnnotations;
using Dukkantek.Domain.Models.Enums;

namespace Dukkantek.Domain.Contracts.Requests
{
    public class CreateProductRequest
    {
        [Required, MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string BarCode { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public double Weight { get; set; }
        public ProductStatus ProductStatus { get; set; }

        public int CategoryId { get; set; }

    }
}
