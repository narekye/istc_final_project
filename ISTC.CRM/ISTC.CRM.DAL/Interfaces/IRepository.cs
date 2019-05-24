using System;
using System.Collections.Generic;
using System.Text;

namespace ISTC.CRM.DAL.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        void Add(T entity);

        T GetById(int id);

        IEnumerable<T> GetAll();

        void Delete(T entity);

        void Update(T entity);
    }
}
