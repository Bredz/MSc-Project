using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.Entity;
using System.Linq.Expressions;

//using NIS.NIMS.Data.Core.Interfaces;
//using NIS.NIMS.Common.Utils.ExtensionMethods;

using System.Data.Entity.Core.Objects;
using MastersProject.Core.Common.Interfaces;
using MastersProject.Core.DataAccessLayer.Interfaces;
using MastersProject.Core.Common.Enums;

namespace MastersProject.Core.DataAccessLayer
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class,IObjectState
    {
        private DbContext _context;
        //public DbContext Context
        //{
        //    get
        //    {
        //        return _context;
        //    }
        //    set
        //    {
        //        _context = value;
        //        // throw new NotImplementedException();
        //    }
        //}
        //public RepositoryBase(/*,IExceptionManager exm*/)
        //{
        //    // _exManager = exm;
        //}
        //[Obsolete("N/A",true)]
        public RepositoryBase(DbContext ctx/*,IExceptionManager exm*/)
        {
            // _exManager = exm;
            _context = ctx;
        }
       
       
        /// <summary>
        /// Returns all entities within the entity set
        /// </summary>
        /// <returns>IEnumerable of T</returns>
        async Task<IEnumerable<T>> IRepositoryBase<T>.GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        /// <summary>
        /// This provides the ability to further filter a query before its executed on the server
        /// </summary>
        /// <param name="filter">lamba</param>
        /// <returns></returns>
        public IQueryable<T> Query(Expression<Func<T, bool>> filter)
        {

            return _context.Set<T>().Where(filter);
        }
        /// <summary>
        /// This provides the ability to further filter a query before its executed on the server without any tracking involved
        /// </summary>
        /// <param name="filter">lamba</param>
        /// <returns></returns>
        public IQueryable<T> QueryAsNoTracking(Expression<Func<T, bool>> filter)
        {

            return _context.Set<T>().Where(filter).AsNoTracking<T>();
        }
        /// <summary>
        /// This works for graphs
        /// </summary>
        /// <param name="entity"></param>
        //public void Add(T entity)
        //{
        //    if (entity.State == Common.Enums.ObjectState.Unchanged)
        //        throw new NIMS.Common.NimsException("you are inserting a record but the state is set to unchanged, please correct.");

        //   // entity.UpdateRowVersion();
        //    _context.Set<T>().Add(entity);
        //    //throw new NotImplementedException();
        //}
        /// <summary>
        /// Only the root entity state will be set to Added
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(T entity)
        {
            
            _context.Set<T>().Attach(entity);
            //entity.State = NIS.NIMS.Common.Enums.ObjectState.Added;
           // _context.Datab(entity);
        }

        public virtual void InsertRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                Insert(entity);
        }
        /// <summary>
        /// Root entity and related entities state will be set to Added
        /// </summary>
        /// <param name="entity"></param>
        //public virtual void InsertGraph(T entity)
        //{
        //     _context.Set<T>().Add(entity);
        //}

        //public virtual void InsertGraphRange(IEnumerable<T> entities)
        //{
        //    _context.Set<T>().AddRange(entities);
        //}



        /// <summary>
        /// No need to set State of T, this is done automatically
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(T entity)
        {
            entity.State = ObjectState.Deleted;
            _context.Set<T>().Remove(entity);
        }
        /// <summary>
        /// No need to set State of T, this is done automatically
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task RemoveAsync(int Id)
        {
         var entity=await GetByIdAsync(Id);
         entity.State = ObjectState.Deleted;
          this.Remove(entity);
        }
        /// <summary>
        /// No need to set State of T, this is done automatically
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task RemoveAsync(Guid Id)
        {
            var entity = await GetByIdAsync(Id);
            entity.State = ObjectState.Deleted;
            this.Remove(entity);
        }
        /// <summary>
        /// No need to set State of T, this is done automatically
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public void Remove(int Id)
        {
            var entity = GetById(Id);
            entity.State = ObjectState.Deleted;
            this.Remove(entity);
        }
        /// <summary>
        /// No need to set State of T, this is done automatically
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public void Remove(Guid Id)
        {
            var entity = GetById(Id);
            entity.State = ObjectState.Deleted;
            this.Remove(entity);
        }
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="entity"></param>
        public void Update(T entity)
        {
           // _context.Entry<T>(entity).State = EntityState.Modified;
           // entity.State = Common.Enums.ObjectState.Modified;

            //if (entity.State == NIS.NIMS.Common.Enums.ObjectState.Unchanged)
            //    throw new NIS.NIMS.Common.NimsException("you are updating a record but the state is set to unchanged, please correct.");
           //check if Entity has a RowVersion property
            //if it does update
            //entity.UpdateRowVersion();
           
            _context.Set<T>().Attach(entity);
            //_context.Entry<T>(entity).State = EntityState.Modified;
        }
        /// <summary>
        /// This function will load the realted entities based on the supplied navigational properties
        /// </summary>
        /// <param name="includeProperties">A comma separated list of navigational properties to include</param>
        /// <returns></returns>
        public IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
           IQueryable<T> t = _context.Set<T>();
           foreach (var i in includeProperties)
	            {
		             t=_context.Set<T>().Include(i);
	            }
          return t;
        }


        public int Count(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().Count(filter);
        }

        public bool Any(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().Any(filter);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async  Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

       public IEnumerable<T> GetAllAsNoTracking()
        {
            return _context.Set<T>().AsNoTracking<T>();
        }

       public IQueryable<T> QueryAllAsNoTracking(Expression<Func<T, bool>> filter)
       {
           return _context.Set<T>().Where(filter).AsNoTracking<T>();
       }

        public  IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }


        IQueryable<T> IRepositoryBase<T>.GetAllQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }

        public decimal Sum(Expression<Func<T, decimal>> selector, Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().Where(filter).Sum(selector);
        }

        public decimal Sum(Expression<Func<T, decimal>> selector)
        {
            return _context.Set<T>().Sum(selector);
        }

        /// <summary>
        /// As with any API that accepts SQL it is important to parameterize any user input to protect against a SQL injection attack.
        /// You can include parameter place holders in the SQL query string and then supply parameter values as additional arguments
        /// </summary>
        /// <param name="queryExpression">select * from [table] where [column]=@p0 and [column]=@p1</param>
        /// <param name="parameters">parameters for query</param>
        /// <returns></returns>
        public IEnumerable<T> SQLQuery(string queryExpression,params object[] parameters)
        {
           return _context.Set<T>().SqlQuery(queryExpression, parameters);
        }
      
    }
    
   
}
