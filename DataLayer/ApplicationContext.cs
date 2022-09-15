using EntitiesDataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataLayer
{
    public class ApplicationContext: DbContext
    {
        private readonly IConfiguration confuguration;
        public ApplicationContext(DbContextOptions<ApplicationContext>options):base(options)
        {
            Database.Migrate();
        }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
    }
}