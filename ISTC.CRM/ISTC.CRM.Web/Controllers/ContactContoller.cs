using Microsoft.AspNetCore.Mvc;

namespace ISTC.CRM.Web.Controllers
{
    public class ContactContoller : Controller
    {
        public ContactContoller()
        {

        }

        public ActionResult Index()
        {
            return Ok();
        }
    }
}
