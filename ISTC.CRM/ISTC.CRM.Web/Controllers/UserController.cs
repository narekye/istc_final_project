using Microsoft.AspNetCore.Mvc;

namespace ISTC.CRM.Web.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        public UserController()
        {

        }

        [HttpGet]
        public ActionResult Index()
        {
            return Ok(new[] { "value1", "value2" });
        }
    }
}
