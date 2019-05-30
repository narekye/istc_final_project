using ISTC.CRM.BLL.Interfaces;
using ISTC.CRM.BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace ISTC.CRM.Web.Controllers
{
    public class EmailListController : ControllerBase
    {
        private readonly IEmailListService _emailListService;

        public EmailListController(IEmailListService emailListService)
        {
            _emailListService = emailListService;
        }

        [HttpGet]
        public ActionResult GetEmailLists()
        {
            var data = _emailListService.GetAll();

            return Ok(data);
        }

        [HttpGet]
        public ActionResult GetEmailListById(int id)
        {
            var emailList = _emailListService.GetEmailListById(id);

            return Ok(emailList);
        }

        [HttpPost]
        public ActionResult CreateEmailList(EmailListsBL emaillist)
        {
            var newEmailList = _emailListService.CreateEmailList(emaillist);

            return Ok(newEmailList);
        }

        [HttpPost]
        public ActionResult AddUserToEmailList(int emailListId, int userId)
        {
            _emailListService.AddUserToEmailList(emailListId, userId);

            return Ok(new object());
        }

        //[HttpPost]
        //public ActionResult SendEmailToMailingList(int emailListId)
        //{
            
        //}
    }
}
