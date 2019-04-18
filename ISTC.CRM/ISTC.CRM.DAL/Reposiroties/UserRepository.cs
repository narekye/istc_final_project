using System;
using System.Collections.Generic;
using System.Text;
using ISTC.CRM.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ISTC.CRM.DAL.Reposiroties
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public User GetByEmail(string email)
        {
            foreach(User item in _context.Set<User>())
            {
                if (item.Email == email)
                    return item;
            }
            return null;
        }

        public IEnumerable<User> GetByEmail(string name)
        {
            var eee = from c in _context.Set<User>()
                      where c.
        }
    }
}
