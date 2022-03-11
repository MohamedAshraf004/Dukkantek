using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dukkantek.DataAccess.Data;
using Dukkantek.Domain.Constants;
using Dukkantek.Domain.Contracts;
using Dukkantek.Domain.Contracts.Responses;
using Dukkantek.Domain.IRepos;
using Dukkantek.Domain.Models;
using Dukkantek.Domain.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Dukkantek.DataAccess.Repos
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly DukkantekContext _context;

        public ProductRepository(DukkantekContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Response<string>> UpdateProductStatusAsync(int productId, ProductStatus productStatus)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
            if (product is null)
                return new()
                {
                    IsSuccess = false,
                    Errors = new List<string>()
                    {
                        SD.NotFound
                    }
                };
            product.ProductStatus = productStatus;

            return new()
            {
                IsSuccess = await _context.SaveChangesAsync() > 0
            };
        }

        public async Task<Response<IEnumerable<ProductCountResponse>>> CountProductsAsync()
        {
            var productsCount = _context.Products.AsNoTracking()
                .GroupBy(x => x.ProductStatus)
                .Select(x => 
                    new ProductCountResponse { Name = x.Key.ToString(), Count = x.Count()});
            return new()
            {
                IsSuccess = true,
                Data = productsCount
            };
        }
    }
}
