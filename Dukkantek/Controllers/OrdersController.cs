using System.Threading.Tasks;
using Dukkantek.Domain.Contracts.Requests;
using Dukkantek.Domain.IRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dukkantek.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync(CreateOrderRequest request)
        {
            var response = await _orderRepository.CreateOrderAsync(request);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
