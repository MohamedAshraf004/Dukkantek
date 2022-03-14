using System.Threading.Tasks;
using Dukkantek.Domain.Contracts;
using Dukkantek.Domain.Contracts.Requests;
using Dukkantek.Domain.Models;

namespace Dukkantek.Domain.IRepos
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Response<string>> CreateOrderAsync(CreateOrderRequest request);
    }
}
