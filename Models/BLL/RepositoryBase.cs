using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Models.BOL;

namespace Models.DAL
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected MentorsContext MentorsContext { get; set; }

        public RepositoryBase(MentorsContext mentorsContext)
        {
            this.MentorsContext = mentorsContext;
        }

        #region IRepository Members
        public IEnumerable<T> FindAll()
        {
            return this.MentorsContext.Set<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.MentorsContext.Set<T>().Where(expression);
        }

        public void Create(T entity)
        {
            this.MentorsContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.MentorsContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.MentorsContext.Set<T>().Remove(entity);
        }

        public void Save()
        {
            this.MentorsContext.SaveChanges();
        }
        #endregion
    }
}

