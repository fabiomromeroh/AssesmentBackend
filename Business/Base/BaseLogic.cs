using Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business
{
    public abstract class BaseLogic<T, R> : IBaseLogic<T>
        where T : class, new()
        where R : IBaseRepository<T>, new()
    {
        private R _repo;
        public R Repo
        {
            get
            {
                if (this._repo == null)
                {
                    this._repo = new R();
                }

                return this._repo;
            }
        }

        public virtual void Add(T entity)
        {
            this.Repo.Add(entity);
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException(); 
        }

        public virtual IEnumerable<T> GetAll()
        {
            throw new NotImplementedException(); 
        }

        public virtual T GetById(int id)
        {
            throw new NotImplementedException(); 
        }

        public virtual void Remove(T entity)
        {
            throw new NotImplementedException(); 
        }

        public virtual void RemoveById(int id)
        {
            this.Repo.RemoveById(id);
        }

        public virtual T Update(T entity)
        {
            return this.Repo.Update(entity);
        }
    
    }
}
