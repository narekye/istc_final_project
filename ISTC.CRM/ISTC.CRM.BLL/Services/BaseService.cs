using ISTC.CRM.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISTC.CRM.BLL.Services
{
    public class BaseService
    {
        protected IUnitOfWork UnitOfWork { get; }

        public BaseService()
        {
            UnitOfWork = new UnitOfWork(null);
        }
    }
}
