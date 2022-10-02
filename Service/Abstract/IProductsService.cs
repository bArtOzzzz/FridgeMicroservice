using Services.Dto;

namespace Services.Abstract
{
    public interface IProductsService
    {
        // POST
        Task<Guid> CreateAsync(ProductDto product);

        // PUT
        Task<Guid> UpdateAsync(ProductDto product, string name);

        // DELETE
        Task<bool> DeleteAsync(ProductDto product);
    }
}
