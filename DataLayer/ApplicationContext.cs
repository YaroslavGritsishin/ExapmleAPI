using EntitiesDataLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) => Database.Migrate();
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
    }
}