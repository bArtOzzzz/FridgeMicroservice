using Services.Dto;

namespace Services.Abstract
{
    public interface IFridgeProductsService
    {
        // GET
        Task<List<FridgeProductDto>> GetAllAsync();
        Task<FridgeProductDto?> GetByIdAsync(Guid fridgeProductId);
        Task<List<FridgeProductDto>> GetFridgeProductsByFridgeIdAsync(Guid fridgeId);

        // PUT
        Task<Guid> UpdateAsync(Guid fridgeProductId, FridgeProductDto fridgeProduct);

        // POST
        Task<Guid[]> CreateAsync(Guid fridgeId, FridgeProductDto fridgeProduct);

        // DELETE
        Task<bool> DeleteAsync(FridgeProductDto fridgeProduct);

        // EXISTS
        Task<bool> IsExistAsync(Guid fridgeProductId);
        Task<bool> IsExistFridgeAsync(Guid fridgeId);
    }
}
