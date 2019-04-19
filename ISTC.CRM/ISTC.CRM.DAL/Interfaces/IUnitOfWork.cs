using ISTC.CRM.DAL.Repositories;

namespace ISTC.CRM.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        UserRepository UserRepository { get; }
        EmailListRepository EmailListRepository { get; }

        int SaveChanges();
    }
}
