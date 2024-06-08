using Microsoft.AspNetCore.Mvc;
using Smarti.Services.Interfaces;

namespace Smarti.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuperMarketController : ControllerBase
    {


        private readonly ILogger<SuperMarketController> _logger;
       // private IGeneralServices generalServices;

        public SuperMarketController(ILogger<SuperMarketController> logger/*, IGeneralServices _generalServices*/)
        {
            _logger = logger;
            //generalServices = _generalServices;
        }

        [HttpGet(Name = "GetPerson")]
        public async Task<ActionResult<object>> Get()
        {
            
           // var person = generalServices.SetProperties<PersonEntity>();
            return null;
        }


    }
}
