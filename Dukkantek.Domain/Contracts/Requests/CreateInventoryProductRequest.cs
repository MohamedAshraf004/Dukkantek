using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Domain.Contracts.Requests
{
    public class CreateInventoryProductRequest
    {
        public int InventoryId { get; set; }
        public double Quantity { get; set; }

    }
}
