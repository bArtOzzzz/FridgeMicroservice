using Repositories.Abstract;
using Repositories.Entities;
using Services.Abstract;
using Services.Dto;
using AutoMapper;

namespace Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;

        public ProductsService(IProductsRepository productsRepository,
                               IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        // POST
        public async Task<Guid> CreateAsync(ProductDto product)
        {
            var productMap = _mapper.Map<ProductEntity>(product);

            await _productsRepository.CreateAsync(productMap);

            return productMap.Id;
        }

        // PUT
        public async Task<Guid> UpdateAsync(ProductDto product, string name)
        {
            var productMessageData = _mapper.Map<ProductEntity>(await _productsRepository.GetByNameAsync(product.PreviousName!));

            return await _productsRepository.UpdateAsync(productMessageData, name);
        }

        // DELETE
        public async Task<bool> DeleteAsync(ProductDto product)
        {
            ProductEntity? productExist = await _productsRepository.GetByNameAsync(product.Name!);

            return await _productsRepository.DeleteAsync(productExist!);
        }
    }
}
