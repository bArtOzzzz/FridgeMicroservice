using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using Repositories.Context;
using Repositories.Entities;

namespace Repositories
{
    public class ModelsRepository : IModelsRepository
    {
        private readonly DataContext _context;

        // DB
        public ModelsRepository(DataContext context) => _context = context;

        // GET
        public async Task<List<ModelEntity>> GetAllAsync()
        {
            return await _context.Models.AsNoTracking()
                                        .ToListAsync();
        }

        public async Task<ModelEntity?> GetByIdAsync(Guid id)
        {
            return await _context.Models.Where(m => m.Id.Equals(id))
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync();
        }

        // POST
        public async Task<Guid> CreateAsync(ModelEntity model)
        {
            ModelEntity modelEntity = new()
            {
                CreatedDate = DateTime.Now,
                Name = model.Name,
                ProductionYear = model.ProductionYear
            };

            await _context.AddAsync(modelEntity);
            await _context.SaveChangesAsync();

            model.Id = modelEntity.Id;

            return model.Id;
        }

        // PUT
        public async Task<Guid> UpdateAsync(Guid modelId, ModelEntity model)
        {
            var currentModel = await _context.Models.Where(m => m.Id.Equals(modelId))
                                                    .FirstOrDefaultAsync();

            currentModel.Name = model.Name;
            currentModel.ProductionYear = model.ProductionYear;

            _context.Update(currentModel);
            await _context.SaveChangesAsync();

            return modelId;
        }

        // DELETE
        public async Task<bool> DeleteAsync(ModelEntity model)
        {
            _context.Remove(model);
            var saved = _context.SaveChangesAsync();

            return await saved > 0;
        }

        // EXISTS
        public async Task<bool> IsExist(Guid id)
        {
            return await _context.Models.FindAsync(id) != null;
        }
    }
}
