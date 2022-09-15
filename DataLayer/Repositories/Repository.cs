using DataLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataLayer.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext context;
        public Repository(DbContext context)
        {
            this.context = context;
        }
        public virtual async Task CreateAsync(TEntity entity)
                => await context.Set<TEntity>().AddAsync(entity);
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
                => await context.Set<TEntity>().AsNoTracking().ToListAsync();
        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
                => await context.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(predicate);
        public virtual async Task<IEnumerable<TEntity>> GetWithIncludeAsync(params Expression<Func<TEntity, object>>[] includeProperties)
                => await Include(includeProperties).ToListAsync();
        public virtual Task RemoveAsync(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            return Task.CompletedTask;
        }
        public abstract Task UpdateAsync(TEntity entity);

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = context.Set<TEntity>().AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
