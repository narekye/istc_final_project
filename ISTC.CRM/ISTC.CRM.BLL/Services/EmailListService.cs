using ISTC.CRM.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISTC.CRM.BLL.Services
{
    class EmailListService : BaseService
    {
        public IEnumerable<EmailListsBL> GetAll()
        {
            var dalUsers = UnitOfWork.EmailListRepository.GetAll();

            return dalUsers.Select(x =>
                new EmailListsBL
                {
                    Id = x.Id,
                    MailListName = x.MailListName,
                    ConnectionTable = x.ConnectionTable;
                });
        }
    }
}
