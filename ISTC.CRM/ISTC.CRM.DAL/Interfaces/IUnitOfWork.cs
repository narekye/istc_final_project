using ISTC.CRM.DAL.Reposiroties;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISTC.CRM.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        UserRepository UserRepository { get; }
        EmailListRepository EmailListRepository { get; }

        int SaveChanges();
    }
}
