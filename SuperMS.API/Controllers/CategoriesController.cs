using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smarti.Controllers;
using SuperMS.Domain;

namespace SuperMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        // private IGeneralServices generalServices;

        public CategoriesController(ILogger<CategoriesController> logger/*, IGeneralServices _generalServices*/)
        {
            _logger = logger;
            //generalServices = _generalServices;
        }

        [HttpGet(Name = "GetCategories")]
        public async Task<ActionResult<CategoriesEntity>> Get()
        {

            // var person = generalServices.SetProperties<PersonEntity>();
            return null;
        }
    }
}
