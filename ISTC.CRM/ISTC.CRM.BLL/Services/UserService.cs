using ISTC.CRM.BLL.Interfaces;
using ISTC.CRM.BLL.Models;
using ISTC.CRM.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISTC.CRM.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(CRMContext context) : base(context)
        {

        }

        public IEnumerable<UserBL> GetAll()
        {
            var dalUsers = UnitOfWork.UserRepository.GetAll();

            return dalUsers.Select(x =>
                new UserBL
                {
                    Id = x.Id,
                    Name = x.Name,
                    Surname = x.Surname,
                    Country = x.Country,
                    CompanyName = x.CompanyName,
                    Position = x.Position,
                    Email = x.Email,
                    //ConnectionTableBL = x.ConnectionTable 
                });
        }
    }
}
