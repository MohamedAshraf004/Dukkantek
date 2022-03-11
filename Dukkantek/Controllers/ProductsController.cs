using System.Threading.Tasks;
using AutoMapper;
using Dukkantek.Domain.Contracts;
using Dukkantek.Domain.Contracts.Requests;
using Dukkantek.Domain.IRepos;
using Dukkantek.Domain.Models;
using Dukkantek.Domain.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dukkantek.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet("Count")]
        public async Task<IActionResult> CountProductsAsync()
            => Ok(await _productRepository.CountProductsAsync());
        [HttpGet]
        public async Task<IActionResult> ProductsAsync()
            => Ok(await _productRepository.GetAllAsync());
        [HttpGet("{id}")]
        public async Task<IActionResult> ProductAsync(int id)
            => Ok(await _productRepository.GetFirstOrDefaultAsync(x=>x.Id==id));
        [HttpPost]
        public async Task<IActionResult> ProductAsync(CreateProductRequest request)
            => Ok(new Response<bool>
            {
                IsSuccess = await _productRepository.AddAsync(_mapper.Map<Product>(request))
            });
        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeProductStatusAsync(int id, ProductStatus productStatus)
            => Ok((await _productRepository.UpdateProductStatusAsync(id, productStatus)));


    }
}
