using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using API.ExceptionHandler;
using API.Model;
using API.Provider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductDataProvider _productDataProvider;

        public ProductsController(IProductDataProvider productDataProvider)
        {
            _productDataProvider = productDataProvider;
        }

        /// <summary>
        /// Get products based on consumption
        /// </summary>
        /// <param name="consumption">Consumption (kWh/year)</param>
        /// <returns><seealso cref="IReadOnlyList{Product}"/></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
         public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts(int consumption)
        {
            var productOutcome = await _productDataProvider.GetProductsAsync(consumption);

            if (productOutcome.Successful)
                return Ok(productOutcome.Result);
            else
                return NotFound(new ApiResponse((int)HttpStatusCode.NotFound, productOutcome.ErrorMessage));
        }
    }
}