using ISTC.CRM.DAL.Interfaces;
using ISTC.CRM.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace ISTC.CRM.DAL.Reposiroties
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly CRMContext _context;

        public Repository(CRMContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
