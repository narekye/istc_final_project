using ISTC.CRM.BLL.Models;
using System.Collections.Generic;

namespace ISTC.CRM.BLL.Interfaces
{
    public interface IEmailListService
    {
        IEnumerable<EmailListsBL> GetAll();

        EmailListsBL GetEmailListById(int emailListId);

        EmailListsBL CreateEmailList(EmailListsBL emailList);

        void AddUserToEmailList(int emailListId, int userId);

        void AddEmailList(EmailListsBL emailList);

        void EditEmailList(EmailListsBL emailList);

        void DeleteEmailListById(int emailListId);
    }
}

