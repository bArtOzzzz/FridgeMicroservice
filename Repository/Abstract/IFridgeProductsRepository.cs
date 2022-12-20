using Repositories.Entities;

namespace Repositories.Abstract
{
    public interface IFridgeProductsRepository
    {
        // GET
        Task<List<FridgeProductEntity>> GetAllAsync();
        Task<FridgeProductEntity?> GetByIdAsync(Guid fridgeProductId);
        Task<List<FridgeProductEntity>> GetFridgeProductsByProductIdAsync(Guid productId);

        // PUT
        Task<Guid> UpdateAsync(Guid fridgeProductId, FridgeProductEntity fridgeProduct);

        // POST
        Task<Guid[]> CreateAsync(Guid fridgeId, FridgeProductEntity fridgeProduct);

        // DELETE
        Task<bool> DeleteAsync(FridgeProductEntity fridgeProduct);

        // EXISTS
        Task<bool> IsExistAsync(Guid fridgeProductId);
        Task<bool> IsExistAsync(FridgeProductEntity fridgeProduct);
        Task<bool> IsExistFridgeAsync(Guid fridgeId);
        Task<bool> IsExistProductAsync(Guid productId);
    }
}
