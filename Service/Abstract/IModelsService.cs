using Services.Dto;

namespace Services.Abstract
{
    public interface IModelsService
    {
        // GET
        Task<List<ModelDto>> GetAllAsync();
        Task<ModelDto?> GetByIdAsync(Guid modelId);

        // POST
        Task<Guid> CreateAsync(ModelDto model);

        // PUT
        Task<Guid> UpdateAsync(Guid modelId, ModelDto model);

        // DELETE
        Task<bool> DeleteAsync(ModelDto model);

        // EXISTS
        Task<bool> IsExist(Guid modelId);
    }
}
