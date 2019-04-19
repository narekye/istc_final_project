using System;
using System.Collections.Generic;
using System.Text;
using ISTC.CRM.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ISTC.CRM.DAL.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
    }
}
