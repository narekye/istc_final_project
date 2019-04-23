using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISTC.CRM.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ISTC.CRM.DAL.Reposiroties
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(CRMContext context) : base(context)
        {
        }

        public User GetByEmail(string email)
        {
           return _context.Set<User>().FirstOrDefault(e => e.Email == email);
        }

        public IEnumerable<User> GetByName(string name)
        {
           return _context.Set<User>().Where(e => e.Name == name).ToList();
        }

        public IEnumerable<User> GetBySurname(string surname)
        {
            return _context.Set<User>().Where(e => e.Surname == surname).ToList();
        }

        public IEnumerable<User> GetByCountrye(string country)
        {
            return _context.Set<User>().Where(e => e.Country == country).ToList();
        }

        public IEnumerable<User> GetByCompanyName(string companyName)
        {
            return _context.Set<User>().Where(e => e.CompanyName == companyName).ToList();
        }

        public IEnumerable<User> GetByPosition(string position)
        {
            return _context.Set<User>().Where(e => e.Position == position).ToList();
        }
    }
}
