using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMS.Domain;

namespace SuperMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private ICategoriesService categoriesService;

        public CategoriesController(ILogger<CategoriesController> logger, ICategoriesService _categoriesService)
        {
            _logger = logger;
            categoriesService = _categoriesService;

        }

        [HttpGet(Name = "GetCategories")]
        public async Task<ActionResult<CategoriesEntity>> Get()
        {

            var categoriesList = categoriesService.GetCategories();
            return Ok(categoriesList);
        }
    }
}
