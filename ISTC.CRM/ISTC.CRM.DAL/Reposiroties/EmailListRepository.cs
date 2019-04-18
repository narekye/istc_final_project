using Microsoft.EntityFrameworkCore;

namespace ISTC.CRM.DAL.Reposiroties
{
    class EmailListRepository : Repository<EmailList>
    {
        public EmailListRepository(DbContext context) : base(context)
        {
        }
    }
}
