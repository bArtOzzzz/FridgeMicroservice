using Repositories.Entities;

namespace Repositories.Abstract
{
    public interface IFridgeProductsRepository
    {
        // GET
        Task<List<FridgeProductEntity>> GetAllAsync();
        Task<FridgeProductEntity?> GetByIdAsync(Guid id);
        Task<List<FridgeProductEntity>> GetFridgeProductsByFridgeIdAsync(Guid fridgeId);

        // PUT
        Task<Guid> UpdateAsync(Guid fridgeProductId, FridgeProductEntity fridgeProduct);

        // POST
        Task<Guid[]> CreateAsync(Guid fridgeID, FridgeProductEntity fridgeProduct);

        // DELETE
        Task<bool> DeleteAsync(FridgeProductEntity fridgeProduct);

        // EXISTS
        Task<bool> IsExistAsync(Guid productId);
        Task<bool> IsExistFridgeAsync(Guid fridgeId);
    }
}
