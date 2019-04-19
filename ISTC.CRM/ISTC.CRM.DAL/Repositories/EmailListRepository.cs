using ISTC.CRM.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ISTC.CRM.DAL.Repositories
{
    public class EmailListRepository : Repository<MailLists>
    {
        public EmailListRepository(DbContext context) : base(context)
        {
        }
    }
}
