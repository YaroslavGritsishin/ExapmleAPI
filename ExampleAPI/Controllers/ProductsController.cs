using BusinessLogicLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ExampleAPI.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> logger;
        private readonly IProductService productService;
        public ProductsController(ILogger<ProductsController> logger, IProductService productService)
        {
            this.logger = logger;
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await productService.GetProductsAsync();
            if (!products.Any())
            {
                await productService.InitDataBaseAsync();
                products = await productService.GetProductsAsync();
            }
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await productService.GetProductByIdAsync(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound("Product not found");
        }
    }
}