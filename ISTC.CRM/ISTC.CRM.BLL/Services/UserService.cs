using ISTC.CRM.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISTC.CRM.BLL.Services
{
    public class UserService : BaseService
    {
        public IEnumerable<UserModel> GetAll()
        {
            var dalUsers = UnitOfWork.UserRepository.GetAll();

            return dalUsers
                .Select(x => 
                new UserModel
                {
                    Id = x.Id,
                    Name = x.Name
                }); 
        }
    }
}
