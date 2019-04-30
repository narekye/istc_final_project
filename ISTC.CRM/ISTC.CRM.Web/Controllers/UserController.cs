using ISTC.CRM.BLL.Interfaces;
using ISTC.CRM.Web.Controllers.Core;
using Microsoft.AspNetCore.Mvc;

namespace ISTC.CRM.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _service;

        // See BLLServiceCollection class, and startup class for this project
        public UserController(IUserService service)
        {
            // _service = new UserService();
            // Don't do this
            _service = service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            // Get all BLL layer users, and send it to the client
            var users = _service.GetAll();

            return Ok(users);
        }
    }
}
