using BusinessLogicLayer.Abstract;
using DataLayer.Abstract;
using DomainEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject;

namespace BusinessLogicLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<ProductDomain> GetProductByIdAsync(int id)
        {
            var result = await unitOfWork.ProductRepository.GetWithIncludeAsync(p => p.Id == id, include => include.Category);
            return result.ToDomain();
        }

        public async Task<IEnumerable<ProductDomain>> GetProductsAsync()
        {
            var products = await unitOfWork.ProductRepository.GetWithIncludeAsync(include => include.Category);
            return products.ToDomain();
        }

        public async Task InitDataBaseAsync()
        {
            await unitOfWork.CategoryRepository.CreateAsync(new EntitiesDataLayer.CategoryEntity() { CategoryName = "Products" });
            await unitOfWork.SaveAsync();
            var productCategory = await unitOfWork.CategoryRepository.GetAsync(c => c.CategoryName == "Products");
            await unitOfWork.ProductRepository.CreateAsync(new EntitiesDataLayer.ProductEntity()
            {
                Name = "Milk",
                Price = 11.2,
                Description = "Natural cow milk",
                CategoryId = productCategory.Id,

            });
            await unitOfWork.ProductRepository.CreateAsync(new EntitiesDataLayer.ProductEntity()
            {
                Name = "Bread",
                Price = 5.3,
                Description = "Fresh white bread",
                CategoryId = productCategory.Id
            });
            await unitOfWork.ProductRepository.CreateAsync(new EntitiesDataLayer.ProductEntity()
            {
                Name = "Pasta",
                Price = 15.0,
                Description = "Pasta of Italy",
                CategoryId = productCategory.Id
            });

            await unitOfWork.SaveAsync();
        }
    }
}
