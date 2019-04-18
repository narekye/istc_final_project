using ISTC.CRM.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ISTC.CRM.DAL.Reposiroties
{
    public class EmailListRepository : Repository<EmailLists>
    {
        public EmailListRepository(DbContext context) : base(context)
        {
        }
    }
}
