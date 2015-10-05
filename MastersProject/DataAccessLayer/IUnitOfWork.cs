using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
namespace MastersProject.Core.DataAccessLayer.Interfaces
{
    public interface IUnitOfWork<C> : IDisposable where C : IObjectContextAdapter, new()
    {
       C context { get; }
        Task<int> SaveAsync();
        //DbRawSqlQuery<string> SQLQuery(string queryExpression, params object[] parameters);
       int Save();
       EntityFramework.Audit.AuditLog GetAudit{get;}
    }
}
