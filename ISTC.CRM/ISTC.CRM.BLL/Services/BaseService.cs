using ISTC.CRM.DAL.Interfaces;
using ISTC.CRM.DAL.UnitOfWork;

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
