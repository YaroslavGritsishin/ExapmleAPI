using Microsoft.AspNetCore.Mvc;

namespace ExampleAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Success");
        }
    }
}