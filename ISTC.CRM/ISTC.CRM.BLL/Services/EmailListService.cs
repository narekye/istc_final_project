﻿using ISTC.CRM.BLL.Interfaces;
using ISTC.CRM.BLL.Models;
using ISTC.CRM.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace ISTC.CRM.BLL.Services
{
    internal class EmailListService : BaseService, IEmailListService
    {
        public EmailListService(CRMContext context) : base(context) { }

        public void AddUserToEmailList(int emailListId, int userId)
        {
            var emailList = UnitOfWork.EmailListRepository.GetById(emailListId);

            if (emailList == null)
            {
                throw CreateException("Email list not found..");
            }

            var user = UnitOfWork.UserRepository.GetById(userId);

            if (user == null)
            {
                throw CreateException("User not found..");
            }

            var emailListUserRelation = new ConnectionTable
            {
                EmailListId = emailListId,
                UserId = userId
            };

            UnitOfWork.EmailListUserRepository.Add(emailListUserRelation);

            UnitOfWork.SaveChanges();
        }

        public EmailListsBL CreateEmailList(EmailListsBL emailListModel)
        {
            var emailList = new EmailLists
            {
                EmailListName = emailListModel.MailListName
            };

            UnitOfWork.EmailListRepository.Add(emailList);

            UnitOfWork.SaveChanges();

            return new EmailListsBL
            {
                Id = emailList.Id,
                MailListName = emailList.EmailListName
            };
        }

        public IEnumerable<EmailListsBL> GetAll()
        {
            var dalUsers = UnitOfWork.EmailListRepository.GetAll();

            return dalUsers.Select(x =>
                new EmailListsBL
                {
                    Id = x.Id,
                    MailListName = x.EmailListName,
                });
        }

        public EmailListsBL GetEmailListById(int id)
        {
            var emaillist = UnitOfWork.EmailListRepository.GetById(id);

            return new EmailListsBL
            {
                Id = emaillist.Id,
                MailListName = emaillist.EmailListName
            };
        }

        public void SendEmailToMailingList(int emailListId)
        {
            var mailingList = UnitOfWork.EmailListRepository.GetById(emailListId);

            if (mailingList == null)
            {
                throw CreateException("Mailing list not found..");
            }

            var usersInMailingList = UnitOfWork.EmailListUserRepository.GetAll().Where(x => x.EmailListId == emailListId);

            if (usersInMailingList == null && !usersInMailingList.Any())
            {
                return;
            }

            var gmailSender = new GmailSender().SetCredentials("crm.project.istc@gmail.com", "crm123456").SetSubject("From ISTC");

            var userEmails = usersInMailingList.Select(x => UnitOfWork.UserRepository.GetById(x.UserId)).Where(x => !string.IsNullOrEmpty(x.Email)).Select(x => x.Email).AsEnumerable();

            gmailSender.AddToMailingList(userEmails);

            gmailSender.Send();
        }
    }
}
