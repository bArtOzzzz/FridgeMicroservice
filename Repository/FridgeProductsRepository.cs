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

        public async Task<bool> IsExistFridgeProductAsync(FridgeProductEntity fridgeProduct)
        {
            return await _context.FridgeProducts.Where(fp => fp.FridgeId.Equals(fridgeProduct.FridgeId) &&
                                                             fp.ProductId.Equals(fridgeProduct.ProductId))
                                                .AnyAsync();
        }

        public async Task<bool> IsExistFridgeAsync(Guid fridgeId)
        {
            return await _context.Fridges.FindAsync(fridgeId) != null;
        }
    }
}
