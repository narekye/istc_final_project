using ISTC.CRM.BLL.Models;
using System.Collections.Generic;

namespace ISTC.CRM.BLL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserBL> GetAll();

        UserBL GetUserById(int userId);

        void AddUser(UserBL user);

        void EditUser(UserBL user);

        void DeleteUserById(int userId);
    }
}
