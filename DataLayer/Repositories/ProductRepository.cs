using DataLayer.Abstract;
using EntitiesDataLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class ProductRepository : Repository<ProductEntity>, IProductRepository
    {
        private readonly DbContext context;
        public ProductRepository(DbContext context) : base(context)
        {
            this.context = context;
        }
        public override async Task UpdateAsync(ProductEntity entity)
        {
            var foundEntity = await context.FindAsync<ProductEntity>(entity.Id);
            if (foundEntity != null)
                context.Entry(foundEntity).CurrentValues.SetValues(entity);
            else throw new NullReferenceException("Product not found for update");
        }
    }
}
