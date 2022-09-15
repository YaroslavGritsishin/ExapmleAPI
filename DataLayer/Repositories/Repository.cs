using DataLayer.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext context;
        public Repository(DbContext context)
        {
            this.context = context;
        }
        public virtual async Task CreateAsync(TEntity entity) => await context.Set<TEntity>().AddAsync(entity);
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await context.Set<TEntity>().AsNoTracking().ToListAsync();
        public virtual async Task<TEntity> GetByIdAsync(int id) => await context.Set<TEntity>().FindAsync(id);
        public virtual Task RemoveAsync(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            return Task.CompletedTask;
        }
        public abstract Task UpdateAsync(TEntity entity);
    }
}
