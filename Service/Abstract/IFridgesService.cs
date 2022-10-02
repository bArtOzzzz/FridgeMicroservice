using Services.Dto;

namespace Services.Abstract
{
    public interface IFridgesService
    {
        // GET
        Task<List<FridgeDto>> GetAllAsync();
        Task<FridgeDto?> GetByIdAsync(Guid id);
        Task<List<ProductDto>> GetProductsByFridgeIdAsync(Guid fridgeId);

        // POST
        Task<Guid> CreateAsync(FridgeDto fridge);

        // PUT
        Task<Guid> UpdateAsync(Guid fridgeId, FridgeDto fridge);

        // DELETE
        Task<bool> DeleteAsync(FridgeDto fridge);

        // EXISTS
        Task<bool> IsExistAsync(Guid id);
    }
}
