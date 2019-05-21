using ISTC.CRM.BLL.Interfaces;
using ISTC.CRM.BLL.Models;
using ISTC.CRM.Web.Controllers.Core;
using Microsoft.AspNetCore.Mvc;

namespace ISTC.CRM.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult GetAllUsers()
        {
            var users = _service.GetAll();

            return Ok(users);
        }

        [HttpGet]
        public ActionResult GetUserById(int userId)
        {
            var user = _service.GetUserById(userId);
            return Ok(user);
        }

        [HttpPost]
        public ActionResult AddUser(UserBL user)
        {
            _service.AddUser(user);

            return Ok();
        }

        [HttpPut]
        public ActionResult EditUser(UserBL user)
        {
            _service.EditUser(user);

            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteUser(int userId)
        {
            _service.DeleteUserById(userId);
            return Ok();
        }
    }
}
