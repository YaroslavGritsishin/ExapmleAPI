using DataLayer.Abstract;
using EntitiesDataLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class CategoryRepository : Repository<CategoryEntity>, ICategoryRepository
    {
        private readonly DbContext context;
        public CategoryRepository(DbContext context) : base(context)
        {
            this.context = context;
        }
        public override async Task UpdateAsync(CategoryEntity entity)
        {
            var foundEntity = await context.FindAsync<CategoryEntity>(entity.Id);
            if (foundEntity != null)
                context.Entry(foundEntity).CurrentValues.SetValues(entity);
            else throw new NullReferenceException("Category not found for update");
        }
    }
}
