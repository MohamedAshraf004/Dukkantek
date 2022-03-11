using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Domain.Contracts.Requests
{
    public class CreateOrderDetailsInvtProductRequest
    {
        public double Amount { get; set; }

        public int ProductInventoryId { get; set; }

    }
}
