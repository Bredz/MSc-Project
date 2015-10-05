using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using MastersProject.Core.Common.Interfaces;

namespace MastersProject.Core.DataAccessLayer.Interfaces
{
    /// <summary>
    /// Each Entity is expected to implement IObjectState interface,to extend repository accordingly create extention methods
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryBase<T> where T:class,IObjectState
    {
       
       //DbContext Context { get; set; }
        Task<T> GetByIdAsync(Int32 id);
        Task<T> GetByIdAsync(Guid id);
        T GetById(Int32 id);
        T GetById(Guid id);
        bool Any(Expression<Func<T, bool>> filter);
        int Count(Expression<Func<T, bool>> filter);
        decimal Sum(Expression<Func<T, decimal>> filter);
        decimal Sum(Expression<Func<T, decimal>> selector, Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetAll();
        IQueryable<T> GetAllQueryable();
        IEnumerable<T> GetAllAsNoTracking();
        IQueryable<T> Query(Expression<Func<T, bool>> filter);
        IQueryable<T> QueryAsNoTracking(Expression<Func<T, bool>> filter);
        IEnumerable<T> SQLQuery(string queryExpression,params object[] parameters);
       
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);

        void Insert(T entity);
        void InsertRange(IEnumerable<T> entities);
        //void InsertGraph(T entity);
        //void InsertGraphRange(IEnumerable<T> entities);

        void Remove(T entity);
        Task RemoveAsync(int Id);
        Task RemoveAsync(Guid Id);
        void Remove(int Id);
        void Remove(Guid Id);
        //[Obsolete("",true)]
        void Update(T entity);
       // void Update(T entity,params Action<T,Common.Enums.ObjectState C>[] test);
        //Save() was commented and moved to the Unit of Work class, 
        //since we might share the DbContext.
       // void Save(); 
    }
  
}
