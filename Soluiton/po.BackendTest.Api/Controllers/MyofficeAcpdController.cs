using Microsoft.AspNetCore.Mvc;

namespace po.BackendTest.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MyofficeAcpdController : Controller
    {

    
            [HttpGet]
            public IActionResult GetAll()
            {
                return Ok("API is working!");
            }
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
