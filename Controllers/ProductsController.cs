using Microsoft.AspNetCore.Mvc;
using PharmacyApplication.ProductDetails;

namespace PharmacyApplication.Controllers
{
    [ApiController]
    [Route("api/v1/products")]
    public class ProductController : BaseApiController
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var api = new ProductAPI();
            var productList = await api.ProductGetAsync();

            return api.hasError
                ? BadRequest(productList)
                : Ok(productList);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductInformation productInformation)
        {
            var api = new ProductAPI();
            await api.ProductAddAsync(productInformation);

            return api.hasError
              ? BadRequest(api.lastErrorMessage)
              : Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, string product_name, string product_description, decimal product_price, int product_quantity)
        {
            var api = new ProductAPI();
            await api.ProductPutAsync(id, product_name, product_description, product_price, product_quantity);

            return api.hasError
                ? BadRequest(api.lastErrorMessage)
                : Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var api = new ProductAPI();
            await api.ProductDeleteAsync(id);

            return api.hasError
              ? BadRequest(api.lastErrorMessage)
              : Ok();
        }
    }
}
