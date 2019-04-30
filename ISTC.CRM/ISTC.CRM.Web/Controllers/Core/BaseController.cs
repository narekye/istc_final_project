using Microsoft.AspNetCore.Mvc;

namespace ISTC.CRM.Web.Controllers.Core
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class BaseController : ControllerBase
    {
    }
}
