using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dukkantek.Domain.Contracts;
using Dukkantek.Domain.Contracts.Responses;
using Dukkantek.Domain.Models;
using Dukkantek.Domain.Models.Enums;

namespace Dukkantek.Domain.IRepos
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Response<string>> UpdateProductStatusAsync(int productId, ProductStatus productStatus);
        Task<Response<IEnumerable<ProductCountResponse>>> CountProductsAsync();
    }
}
