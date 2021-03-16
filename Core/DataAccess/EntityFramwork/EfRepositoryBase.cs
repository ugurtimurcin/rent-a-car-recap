using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramwork
{
    public class EfRepositoryBase<T, TContext> : IEntityRepository<T> where T : class, IEntity, new() where TContext : DbContext, new()
    {
        public void Add(T entity)
        {
            using var context = new TContext();
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            using var context = new TContext();
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            using var context = new TContext();
            return context.Set<T>().SingleOrDefault(predicate);
        }

        public List<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            using var context = new TContext();
            return predicate == null ? context.Set<T>().ToList() : context.Set<T>().Where(predicate).ToList();
        }

        public void Update(T entity)
        {
            using var context = new TContext();
            context.Update(entity);
            context.SaveChanges();
        }
    }
}
