using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dto;
using API.Provider;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductDataProvider _productDataProvider;
        private readonly IMapper _mapper;

        public ProductsController(IProductDataProvider productDataProvider, IMapper mapper)
        {
            _productDataProvider = productDataProvider;
            _mapper = mapper;
        }

        /// <summary>
        /// Get products based on consumption
        /// </summary>
        /// <param name="consumption">consumption in kWh/year</param>
        /// <returns><seealso cref="IReadOnlyList{ProductDto}"/></returns>
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts(int consumption)
        {
            var productOutcome = await _productDataProvider.GetProductsAsync(consumption);

            if (productOutcome.Successful)
                return Ok(_mapper.Map<IReadOnlyList<ProductDto>>(productOutcome.Result));
            else
                return BadRequest(productOutcome.ErrorMessage);
        }
    }
}