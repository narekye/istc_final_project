using ISTC.CRM.DAL.Models;
using ISTC.CRM.DAL.UnitOfWork;

namespace ISTC.CRM.BLL.Services
{
    public class BaseService
    {
        protected UnitOfWork UnitOfWork { get; }

        public BaseService(CRMContext context)
        {
            UnitOfWork = new UnitOfWork(context);
        }
    }
}
