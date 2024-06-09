using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMS.Application.Models;
using SuperMS.Domain;

namespace SuperMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private IProductsService productsService;

        public ProductsController(ILogger<ProductsController> logger, IProductsService _productsService)
        {
            _logger = logger;
            productsService = _productsService;

        }

        [HttpGet(Name = "GetProducts")]
        public async Task<ActionResult<List<ProductDTO>>> Get()
        {

            var categoriesList =await productsService.GetProducts();
            return Ok(categoriesList);
        }

        [HttpPost(Name = "AddProducts")]
        public async Task<ActionResult<List<ProductDTO>>> Post([FromBody]ProductDTO product)
        {

            var categoriesList = await productsService.AddProducts(product);
            return Ok(categoriesList);
        }


    }
}
