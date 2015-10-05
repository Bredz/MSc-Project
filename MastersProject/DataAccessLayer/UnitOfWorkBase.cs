

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using EntityFramework.Audit;
using System.Data.Entity.Infrastructure;
using System.Text.RegularExpressions;
using MastersProject.Core.DataAccessLayer.Interfaces;
using MastersProject.Core.Common.Utils;
namespace MastersProject.Core.DataAccessLayer
{
  public  class UnitOfWorkBase<C>:IDisposable,IUnitOfWork<C> where C:DbContext,new()

  {
      private  C _context;
      AuditLogger  auditlog;
      public UnitOfWorkBase()
          //: this(new C())
      {
          _context =new C();
        
          // config audit when your application is starting up...
         // var auditConfiguration = AuditConfiguration.Default;

          //auditConfiguration.IncludeRelationships = true;
          //auditConfiguration.LoadRelationships = true;
          //auditConfiguration.DefaultAuditable = true;
         auditlog = _context.BeginAudit();
      }
      //    public UnitOfWorkBase(C context)
      //{
      //    _context = context;
      //    //TODO wireup loggings
      //  //_context.Database.Log = s => logger.Log("EFApp", s);
      //}
      public int Save()
      {
          //convert IObjectState to respective Entity states
        _context.ApplyStateChanges();
        //commit changes to data store
          var affected = _context.SaveChanges();
          //TODO Audit log
         // var tmp = auditlog.LastLog.ToXml();

       return affected;
      } 
      public AuditLog GetAudit
      {
          get { return auditlog.LastLog; }
      }
      public async Task<int> SaveAsync()
      {
          
              

              //so that the context will know how to deal with each and every entity when dealing with entity graphs.
               _context.ApplyStateChanges();
              //commit changes to data store
              return await _context.SaveChangesAsync();
          
         
      }
     
     
        
      public void Dispose()
      {
         Dispose(true);
         GC.SuppressFinalize(this);
      }
      protected virtual void Dispose(bool disposing)
      {
          if (disposing)
          {
              if(_context!=null)
              {
                  _context.Dispose();
                  _context = null;
              }
          }

      }
  
      public C context
      {
          get { return _context; }
      }


      ///// <summary>
      ///// As with any API that accepts SQL it is important to parameterize any user input to protect against a SQL injection attack.
      ///// You can include parameter place holders in the SQL query string and then supply parameter values as additional arguments
      ///// </summary>
      ///// <param name="queryExpression">select * from [table] where [column]=@p0 and [column]=@p1</param>
      ///// <param name="parameters">parameters for query</param>
      ///// <returns></returns>
      //DbRawSqlQuery<string> IUnitOfWork<C>.SQLQuery(string queryExpression, params object[] parameters)
      //{
      //    return _context.Database.SqlQuery<String>(queryExpression, parameters);
     
      //}
  }
}
