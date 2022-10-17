using Repositories.Entities;

namespace Repositories.Abstract
{
    public interface IModelsRepository
    {
        // GET
        Task<List<ModelEntity>> GetAllAsync();
        Task<ModelEntity?> GetByIdAsync(Guid modelId);

        // POST
        Task<Guid> CreateAsync(ModelEntity model);

        // PUT
        Task<Guid> UpdateAsync(Guid modelId, ModelEntity model);

        // DELETE
        Task<bool> DeleteAsync(ModelEntity model);

        // EXISTS
        Task<bool> IsExist(Guid modelId);
    }
}
