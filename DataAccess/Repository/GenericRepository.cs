﻿using Core.Entities;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        protected IDbContext DbContext { get; set; }

        public GenericRepository(IDbContext context)
        {
            DbContext = context;
        }

        public void Add(T item)
        {
            DbContext.Set<T>();
        }

        public virtual void AddIfNew(T item)
        {
            DbContext.Set<T>().AddIfNotExists(item);
        }

        public virtual void AddOrUpdate(T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            var item = new T { Id = id };
            DbContext.Set<T>().Attach(item);
            DbContext.Set<T>().Remove(item);
        }

        public T FindById(Guid id)
        {
            return DbContext.Set<T>().Get(i => i.Id == id).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return DbContext.Set<T>();
        }

        public void Update(T item)
        {
            DbContext.Set<T>().Attach(item);
            DbContext.Entry(item).State = EntityState.Modified;
        }

        public async Task Save()
        {
            await DbContext.SaveChangesAsync();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().Get(predicate);
        }

        Task<T> IRepository<T>.FindById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
