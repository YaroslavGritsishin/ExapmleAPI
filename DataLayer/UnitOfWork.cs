using DataLayer.Abstract;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext context;
        private IProductRepository productRepository;
        private ICategoryRepository categoryRepository;
        public UnitOfWork(ApplicationContext context)
        {
            this.context = context;
        }
        public IProductRepository ProductRepository => productRepository ??= new ProductRepository(context);
        public ICategoryRepository CategoryRepository => categoryRepository ??= new CategoryRepository(context);
        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
