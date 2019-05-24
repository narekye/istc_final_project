using ISTC.CRM.BLL.Interfaces;
using ISTC.CRM.Web.Controllers.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ISTC.CRM.Web.Controllers
{
    public class EmailListController : BaseController
    {
        private readonly IEmailListService _service;

        public EmailListController(IEmailListService service)
        {
            _service = service;
        }
    }
}
