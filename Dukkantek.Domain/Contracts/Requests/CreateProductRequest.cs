using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
