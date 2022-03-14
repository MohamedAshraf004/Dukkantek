using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dukkantek.DataAccess.Data;
using Dukkantek.Domain.Constants;
using Dukkantek.Domain.Contracts;
using Dukkantek.Domain.Contracts.Requests;
using Dukkantek.Domain.IRepos;
using Dukkantek.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dukkantek.DataAccess.Repos
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly DukkantekContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderRepository> _logger;

        public OrderRepository(DukkantekContext context,IMapper mapper,ILogger<OrderRepository> logger) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<string>> CreateOrderAsync(CreateOrderRequest request)
        {
            try
            {
                await SetProductsPrices(request);
                var order = _mapper.Map<Order>(request);
                // TODO: Need to Issue the quantity for each product from the inventory
                // There is a  better way to do orders in a better schema
                await _context.Orders.AddAsync(order);
                var result = await _context.SaveChangesAsync() > 0;

                return new()
                {
                    IsSuccess = result
                };
            }
            catch (Exception e)
            { 
                _logger.LogError(e,SD.CouldNotAddTheOrder);
                return new()
                {
                    Errors = new List<string>()
                    {
                        $"{SD.CouldNotAddTheOrder}"
                    }
                };
            }
            
        }

        private async Task SetProductsPrices(CreateOrderRequest request)
        {
            var items = await _context.Products.AsNoTracking()
                .Where(x => request.OrderDetails.Select(item => item.ProductId).Contains(x.Id))
                .Select(x => new {x.Id, x.Price})
                .ToListAsync();
            foreach (var orderDetail in request.OrderDetails)
            {
                orderDetail.Price = items.FirstOrDefault(x => x.Id == orderDetail.ProductId)!.Price;
            }
        }
    }
}
