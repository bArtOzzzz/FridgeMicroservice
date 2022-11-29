using Repositories.Entities;

namespace Repositories.Abstract
{
    public interface IFridgesRepository
    {
        // GET
        Task<List<FridgeEntity>> GetAllAsync();
        Task<FridgeEntity?> GetByIdAsync(Guid fridgeId);
        Task<List<ProductEntity?>> GetProductsByFridgeIdAsync(Guid fridgeId);

        // POST
        Task<Guid> CreateAsync(FridgeEntity fridge);

        // PUT
        Task<Guid> UpdateAsync(Guid fridgeId, FridgeEntity fridge);

        // DELETE
        Task<bool> DeleteAsync(FridgeEntity fridge);

        // EXISTS
        Task<bool> IsExistAsync(Guid fridgeId);
    }
}
