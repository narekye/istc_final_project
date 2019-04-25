using ISTC.CRM.BLL.Models;
using System.Collections.Generic;

namespace ISTC.CRM.BLL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserBL> GetAll();
    }
}
