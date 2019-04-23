using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ISTC.CRM.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ISTC.CRM.DAL.Reposiroties
{
    public class EmailListRepository : Repository<EmailLists>
    {
        public EmailListRepository(CRMContext context) : base(context)
        {
        }

        public IEnumerable<EmailLists> GetEmailListSortedByUserCount()
        {
          return  _context.Set<EmailLists>().OrderBy(t => t.ConnectionTable.Count).AsEnumerable();
        }
    }
}
