using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using Repositories.Abstract;
using Repositories.Context;

namespace Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly DataContext _context;

        // DB
        public ProductsRepository(DataContext context) => _context = context;

        // GET
        public async Task<ProductEntity?> GetByNameAsync(string name)
        {
            return await _context.Products.Where(p => p.Name.Equals(name))
                                          .AsNoTracking()
                                          .FirstOrDefaultAsync();
        }

        // POST
        public async Task<Guid> CreateAsync(ProductEntity product)
        {
            ProductEntity productEntity = new()
            {
                Id = product.Id,
                CreatedDate = product.CreatedDate,
                Name = product.Name,
                LinkImage = product.LinkImage
            };

            await _context.AddAsync(productEntity);
            await _context.SaveChangesAsync();

            return productEntity.Id;
        }

        // PUT
        public async Task<Guid> UpdateAsync(ProductEntity product, string name)
        {
            var currentProduct = await _context.Products.Where(m => m.Id
                                                        .Equals(product.Id))
                                                        .FirstOrDefaultAsync();

            currentProduct!.Name = name;
            currentProduct.LinkImage = product.LinkImage;

            _context.Update(currentProduct);
            await _context.SaveChangesAsync();

            return product.Id;
        }

        // DELETE
        public async Task<bool> DeleteAsync(ProductEntity product)
        {
            _context.Remove(product);
            var saved = _context.SaveChangesAsync();

            return await saved > 0;
        }

        // EXISTS
        public async Task<bool> IsExistAsync(Guid id)
        {
            return await _context.Products.FindAsync(id) != null;
        }
    }
}
