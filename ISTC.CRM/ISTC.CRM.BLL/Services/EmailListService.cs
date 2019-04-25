using ISTC.CRM.BLL.Interfaces;
using ISTC.CRM.BLL.Models;
using ISTC.CRM.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace ISTC.CRM.BLL.Services
{
    internal class EmailListService : BaseService, IEmailListService
    {
        public EmailListService(CRMContext context) : base(context)
        {

        }

        public IEnumerable<EmailListsBL> GetAll()
        {
            var dalUsers = UnitOfWork.EmailListRepository.GetAll();

            return dalUsers.Select(x =>
                new EmailListsBL
                {
                    Id = x.Id,
                    MailListName = x.MailListName,
                   // ConnectionTable = x.ConnectionTable;
                });
        }
    }
}
