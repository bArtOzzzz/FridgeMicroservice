using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using Repositories.Entities;
using Repositories.Context;

namespace Repositories
{
    public class FridgeProductsRepository : IFridgeProductsRepository
    {
        private readonly DataContext _context;

        // DB
        public FridgeProductsRepository(DataContext context) => _context = context;

        // GET
        public async Task<List<FridgeProductEntity>> GetAllAsync()
        {
            return await _context.FridgeProducts.AsNoTracking()
                                                .ToListAsync();
        }

        public async Task<FridgeProductEntity?> GetByIdAsync(Guid fridgeProductId)
        {
            return await _context.FridgeProducts.Where(fp => fp.Id.Equals(fridgeProductId))
                                                .AsNoTracking()
                                                .FirstOrDefaultAsync();
        }

        public async Task<List<FridgeProductEntity>> GetFridgeProductsByFridgeIdAsync(Guid fridgeId)
        {
            return await _context.FridgeProducts.Where(fp => fp.FridgeId.Equals(fridgeId))
                                                .AsNoTracking()
                                                .ToListAsync();
        }

        // PUT
        public async Task<Guid> UpdateAsync(Guid fridgeProductId, FridgeProductEntity fridgeProduct)
        {
            var currentFridgeProduct = await _context.FridgeProducts.Where(f => f.Id.Equals(fridgeProductId))
                                                                    .FirstOrDefaultAsync();

            currentFridgeProduct!.ProductCount = fridgeProduct.ProductCount;
            currentFridgeProduct.UpdatedDate = DateTime.UtcNow;

            _context.Update(currentFridgeProduct);
            await _context.SaveChangesAsync();

            return fridgeProductId;
        }

        // POST
        public async Task<Guid[]> CreateAsync(Guid fridgeId, FridgeProductEntity fridgeProduct)
        {
            FridgeProductEntity fridgeProductEntity = new()
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                FridgeId = fridgeId,
                ProductId = fridgeProduct.ProductId,
                ProductCount = fridgeProduct.ProductCount
            };

            await _context.AddAsync(fridgeProductEntity);
            await _context.SaveChangesAsync();

            fridgeProduct.Id = fridgeProductEntity.Id;
            fridgeProduct.ProductId = fridgeProductEntity.ProductId;

            return new Guid[] { fridgeProductEntity.Id, fridgeProductEntity.ProductId, fridgeId };
        }

        // DELETE
        public async Task<bool> DeleteAsync(FridgeProductEntity fridgeProduct)
        {
            _context.Remove(fridgeProduct);
            var saved = _context.SaveChangesAsync();

            return await saved > 0;
        }

        // EXISTS
        public async Task<bool> IsExistAsync(Guid fridgeProductId)
        {
            return await _context.FridgeProducts.FindAsync(fridgeProductId) != null;
        }

        public async Task<bool> IsExistFridgeAsync(Guid fridgeId)
        {
            return await _context.Fridges.FindAsync(fridgeId) != null;
        }

        //________________________________NEW_SECTION___________________________

        public async Task<List<FridgeProductEntity>> Test1()
        {
            return await _context.FridgeProducts.Include(f => f.Fridge)
                                                .ThenInclude(m => m!.Model)
                                                .GroupBy(f => f.Product)
                                                .ToListAsync();
        }

        // Take - Gets the set numbers of entities from collection
        // TakeWhile - Gets the set numbers while condision is true
        // TakeLast - Gets the set numbers of entities from collection and starts at the end of the collection

        // Skip - Skips the set number of entities from collection
        // SkipWhle - ...
        // SkipLast - ...
        public async Task<List<FridgeEntity>> Test2()
        {
            return await _context.Fridges.Include(m => m!.Model)
                                         .Where(u => u.OwnerName!.ToUpper()
                                                                 .StartsWith("E"))
                                         .Take(3)
                                         .OrderByDescending(f => f.Manufacturer)
                                         .ToListAsync();
        }

        //______________________________END_NEW_SECTION_________________________
    }
}
