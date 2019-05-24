using ISTC.CRM.BLL.Models;
using System.Collections.Generic;

namespace ISTC.CRM.BLL.Interfaces
{
    public interface IEmailListService
    {
        IEnumerable<EmailListsBL> GetAll();

        EmailListsBL GetUserById(int userId);

        void AddEmailList(EmailListsBL user);

        void EditEmailList(EmailListsBL user);

        void DeleteEmailListById(int userId);
    }
}
