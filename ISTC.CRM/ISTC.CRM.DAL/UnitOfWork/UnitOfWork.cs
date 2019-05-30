using ISTC.CRM.DAL.Models;
using ISTC.CRM.DAL.Reposiroties;

namespace ISTC.CRM.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CRMContext _context;

        public UserRepository UserRepository { get; }
        public EmailListRepository EmailListRepository { get; }
        public EmailListUserRepository EmailListUserRepository { get; }

        public UnitOfWork(CRMContext context)
        {
            _context = context;
            UserRepository = new UserRepository(_context);
            EmailListRepository = new EmailListRepository(_context);
            EmailListUserRepository = new EmailListUserRepository(_context);
        }

        public int SaveChanges()
        {
            return _context?.SaveChanges() ?? 0;
        }
    }
}
