using Repositories.Entities;

namespace Repositories.Abstract
{
    public interface IProductsRepository
    {
        // GET
        Task<ProductEntity?> GetByNameAsync(string name);

        // POST
        Task<Guid> CreateAsync(ProductEntity product);

        // PUT
        Task<Guid> UpdateAsync(ProductEntity product, string name);

        // DELETE
        Task<bool> DeleteAsync(ProductEntity product);

        // EXISTS
        Task<bool> IsExistAsync(Guid productId);
    }
}
