using System;
using System.Collections.Generic;
using System.Linq;
using SocialNetwork.Domain.Models;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.DataAccess.Context;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private SocialNetworkContext context;

        public Repository(SocialNetworkContext context)
        {
            this.context = context;
        }
        public IQueryable<T> GetAllQuery()
        {
            return context.Set<T>().AsQueryable();
        }
        public ICollection<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public IQueryable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate).AsQueryable();
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            return context.Set<T>().SingleOrDefault(match);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await context.Set<T>().SingleOrDefaultAsync(match);
        }

        public T FindByKey(params object[] keys)
        {
            return context.Set<T>().Find(keys);
        }

        public async Task<T> FindByKeyAsync(params object[] keys)
        {
            return await context.Set<T>().FindAsync(keys);
        }

        public bool Contains(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Count(predicate) > 0;
        }

        public T Add(T entity)
        {
            return context.Set<T>().Add(entity);
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            return context.Set<T>().AddRange(entities);
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            context.Set<T>().RemoveRange(entities);
        }

        public void Update(T entity)
        {
            var entry = context.Entry(entity);
            context.Set<T>().Attach(entity);
            entry.State = EntityState.Modified;
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }        

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
                GC.SuppressFinalize(this);
            }
        }
    }
}