using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using Repositories.Context;
using Repositories.Entities;

namespace Repositories
{
    public class FridgesRepository : IFridgesRepository
    {
        private readonly DataContext _context;

        // DB
        public FridgesRepository(DataContext context) => _context = context;

        // GET
        public async Task<List<FridgeEntity>> GetAllAsync()
        {
            return await _context.Fridges.Include(m => m.Model)
                                         .ToListAsync();
        }

        public async Task<FridgeEntity?> GetByIdAsync(Guid id)
        {
            return await _context.Fridges.Where(f => f.Id.Equals(id))
                                         .AsNoTracking()
                                         .FirstOrDefaultAsync();
        }

        public async Task<List<ProductEntity>> GetProductsByFridgeIdAsync(Guid fridgeId)
        {
            return await _context.FridgeProducts.Where(fp => fp.FridgeId.Equals(fridgeId))
                                                .Select(p => p.Product)
                                                .ToListAsync();
        }

        // POST
        public async Task<Guid> CreateAsync(FridgeEntity fridge)
        {
            FridgeEntity fridgeEntity = new()
            {
                CreatedDate = DateTime.Now,
                Manufacturer = fridge.Manufacturer,
                OwnerName = fridge.OwnerName,
                ModelId = fridge.ModelId
            };

            await _context.AddAsync(fridgeEntity);
            await _context.SaveChangesAsync();

            fridge.Id = fridgeEntity.Id;

            return fridgeEntity.Id;
        }

        // PUT
        public async Task<Guid> UpdateAsync(Guid fridgeId, FridgeEntity fridge)
        {
            var currentFridge = await _context.Fridges.Where(f => f.Id.Equals(fridgeId))
                                                      .FirstOrDefaultAsync();

            currentFridge.Manufacturer = fridge.Manufacturer;
            currentFridge.OwnerName = fridge.OwnerName;

            _context.Update(currentFridge);
            await _context.SaveChangesAsync();

            return fridgeId;
        }

        // DELETE
        public async Task<bool> DeleteAsync(FridgeEntity fridge)
        {
            _context.Remove(fridge);
            var saved = _context.SaveChangesAsync();

            return await saved > 0;
        }

        // EXISTS
        public async Task<bool> IsExistAsync(Guid id)
        {
            return await _context.Fridges.FindAsync(id) != null;
        }
    }
}
