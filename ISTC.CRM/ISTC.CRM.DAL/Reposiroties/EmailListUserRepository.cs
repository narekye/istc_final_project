using ISTC.CRM.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISTC.CRM.DAL.Reposiroties
{
    public class EmailListUserRepository : Repository<ConnectionTable>
    {
        public EmailListUserRepository(CRMContext context) : base(context)
        {
        }
    }
}
