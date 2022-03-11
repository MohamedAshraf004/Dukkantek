using System.Threading.Tasks;
using Dukkantek.Domain.Contracts.Requests;
using Dukkantek.Domain.IRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dukkantek.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("Count")]
        public async Task<IActionResult> CountProductsAsync()
            => Ok(await _productRepository.CountProductsAsync());
        [HttpGet]
        public async Task<IActionResult> ProductsAsync()
            => Ok(await _productRepository.GetAllAsync());
        [HttpGet]
        public async Task<IActionResult> ProductAsync(int id)
            => Ok(await _productRepository.GetFirstOrDefaultAsync(x=>x.Id==id));
        //[HttpPost]
        //public async Task<IActionResult> ProductAsync(CreateProductRequest request)
        //    => Ok(await _productRepository.AddAsync());
    }
}
