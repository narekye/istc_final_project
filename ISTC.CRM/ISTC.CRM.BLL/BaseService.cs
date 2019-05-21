using ISTC.CRM.DAL.Models;
using ISTC.CRM.DAL.UnitOfWork;
using System;

namespace ISTC.CRM.BLL.Services
{
    public class BaseService
    {
        protected UnitOfWork UnitOfWork { get; }

        public BaseService(CRMContext context)
        {
            UnitOfWork = new UnitOfWork(context);
        }

        protected Exception CreateException(params string[] messages)
        {
            return new Exception(string.Join(',', messages));
        }
    }
}
