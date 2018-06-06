using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaskAPI.Models.BOL;

namespace TaskAPI.Models.DAL
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected MemberProjectContext MemberProjectContext { get; set; }

        public RepositoryBase(MemberProjectContext memberProjectContext)
        {
            this.MemberProjectContext = memberProjectContext;
        }

        #region IRepository Members
        public virtual IQueryable<T> GetAll()
        {
            return this.MemberProjectContext.Set<T>();
        }

        public virtual IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return this.MemberProjectContext.Set<T>().Where(expression);
        }

        public virtual void Create(T entity)
        {
            this.MemberProjectContext.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            //this.MemberProjectContext.Set<T>().Update(entity);
            this.MemberProjectContext.Entry(entity).State = EntityState.Modified;
            //return Find(t.id => t.Id.Equals(T.id)).FirstOrDefault();
        }

        public virtual void Delete(T entity)
        {
            this.MemberProjectContext.Set<T>().Remove(entity);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.MemberProjectContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}

