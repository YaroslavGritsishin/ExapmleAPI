using DomainEntity;

namespace BusinessLogicLayer.Abstract
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDomain>> GetProductsAsync();
        Task<ProductDomain> GetProductByIdAsync(int id);
        Task InitDataBaseAsync();
    }
}
