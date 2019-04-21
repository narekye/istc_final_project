using ISTC.CRM.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISTC.CRM.BLL.Services
{
    class ConnectionTableService : BaseService
    {
        public IEnumerable<ConnectionTableBL> GetAll()
        {
            var dalUsers = UnitOfWork..GetAll();

            return dalUsers.Select(x =>
                new UserBL
                {

                });
        }

    }
}
