using System.Threading.Tasks;
using AutoMapper;
using Dukkantek.DataAccess.Data;
using Dukkantek.Domain.Contracts;
using Dukkantek.Domain.Contracts.Requests;
using Dukkantek.Domain.IRepos;
using Dukkantek.Domain.Models;

namespace Dukkantek.DataAccess.Repos
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly DukkantekContext _context;
        private readonly IMapper _mapper;

        public OrderRepository(DukkantekContext context,IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<string>> CreateOrderAsync(CreateOrderRequest request)
        {
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
    }
}
