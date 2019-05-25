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

        public void AddEmailList(EmailListsBL emailList)
        {
            var _emailList = new EmailLists
            {
                Id = emailList.Id,
                MailListName = emailList.MailListName
            };

            var exists = UnitOfWork.EmailListRepository.GetById(_emailList.Id);

            if (exists != null)
            {
                throw CreateException("emailList with the same id already exists");
            }

            UnitOfWork.EmailListRepository.Add(_emailList);

            UnitOfWork.SaveChanges();
        }

        public void DeleteEmailListById(int emailListId)
        {
            if (emailListId <= 0)
            {
                throw CreateException("emailListId not found!!");
            }

            var dalemailList = UnitOfWork.EmailListRepository.GetById(emailListId);

            if (dalemailList == null)
            {
                throw CreateException("emailList with the same id is not found");
            }

            UnitOfWork.EmailListRepository.Delete(dalemailList);

            UnitOfWork.SaveChanges();
        }

        public void EditEmailList(EmailListsBL emailList)
        {
            if (emailList.Id <= 0)
            {
                throw CreateException("emailList not found!!");
            }

            var dalemailList = UnitOfWork.EmailListRepository.GetById(emailList.Id);

            if (dalemailList == null)
            {
                throw CreateException("emailList not found!!");
            }

            if (!string.IsNullOrWhiteSpace(emailList.MailListName))
                dalemailList.MailListName = emailList.MailListName;

            UnitOfWork.SaveChanges();
        }

        public IEnumerable<EmailListsBL> GetAll()
        {
            var dalEmailLists = UnitOfWork.EmailListRepository.GetAll();

            return dalEmailLists.Select(x =>
                new EmailListsBL
                {
                    Id = x.Id,
                    MailListName = x.MailListName,
                   // ConnectionTable = x.ConnectionTable;
                });
        }

        public EmailListsBL GetEmailListsById(int emailListId)
        {
            if (emailListId <= 0)
            {
                throw CreateException("emailList not found!!");
            }

            var dalemailList = UnitOfWork.EmailListRepository.GetById(emailListId);

            if (dalemailList == null)
            {
                throw CreateException("emailList not found");
            }

            return new EmailListsBL()
            {
                Id = dalemailList.Id,
                MailListName = dalemailList.MailListName
            };


        }
    }
}
