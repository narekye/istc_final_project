using Microsoft.EntityFrameworkCore;

namespace ISTC.CRM.DAL.Reposiroties
{
    public class EmailListRepository : Repository<EmailList>
    {
        public EmailListRepository(DbContext context) : base(context)
        {
        }
    }
}
