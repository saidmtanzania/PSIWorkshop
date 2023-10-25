using coreapp.Models;
using coreapp.Services;
using Microsoft.AspNetCore.Mvc;

namespace coreapp.Controllers
{
    [Route("/products")]
    [ApiController]

    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }

        [Route("/products/rate")]
        [HttpGet]
        public ActionResult Get([FromQuery] string pId, [FromQuery] int Rating)
        {
            ProductService.AddRating(pId, Rating);
            return Ok();
        }
    }
}