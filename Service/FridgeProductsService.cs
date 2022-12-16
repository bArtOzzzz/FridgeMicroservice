using Repositories.Abstract;
using Repositories.Entities;
using Services.Abstract;
using Services.Dto;
using AutoMapper;

namespace Services
{
    public class FridgeProductsService : IFridgeProductsService
    {
        private readonly IFridgeProductsRepository _fridgeProductsRepository;
        private readonly IMapper _mapper;

        public FridgeProductsService(IFridgeProductsRepository fridgeProductsRepository,
                                     IMapper mapper)
        {
            _fridgeProductsRepository = fridgeProductsRepository;
            _mapper = mapper;
        }

        // GET
        public async Task<List<FridgeProductDto>> GetAllAsync()
        {
            var fridgeProducts = await _fridgeProductsRepository.GetAllAsync();

            return _mapper.Map<List<FridgeProductDto>>(fridgeProducts);
        }

        public async Task<FridgeProductDto?> GetByIdAsync(Guid fridgeProductId)
        {
            var fridgeProduct = await _fridgeProductsRepository.GetByIdAsync(fridgeProductId);

            return _mapper.Map<FridgeProductDto>(fridgeProduct);
        }

        public async Task<List<FridgeProductDto>> GetFridgeProductsByFridgeIdAsync(Guid fridgeId)
        {
            var fridgeProduct = await _fridgeProductsRepository.GetFridgeProductsByFridgeIdAsync(fridgeId);

            return _mapper.Map<List<FridgeProductDto>>(fridgeProduct);
        }

        // PUT
        public async Task<Guid> UpdateAsync(Guid fridgeProductId, FridgeProductDto fridgeProduct)
        {
            var fridgeProductMap = _mapper.Map<FridgeProductEntity>(fridgeProduct);

            return await _fridgeProductsRepository.UpdateAsync(fridgeProductId, fridgeProductMap);
        }

        // POST
        public async Task<Guid[]> CreateAsync(Guid fridgeId, FridgeProductDto fridgeProduct)
        {
            var fridgeProductMap = _mapper.Map<FridgeProductEntity>(fridgeProduct);

            await _fridgeProductsRepository.CreateAsync(fridgeId, fridgeProductMap);

            fridgeProduct.Id = fridgeProductMap.Id;
            fridgeProduct.ProductId = fridgeProductMap.ProductId;

            return new Guid[] { fridgeProductMap.Id, fridgeProduct.ProductId, fridgeId };
        }

        // DELETE
        public async Task<bool> DeleteAsync(FridgeProductDto fridgeProduct)
        {
            var fridgePropuctMap = _mapper.Map<FridgeProductEntity>(fridgeProduct);

            return await _fridgeProductsRepository.DeleteAsync(fridgePropuctMap);
        }

        // EXISTS
        public async Task<bool> IsExistAsync(Guid fridgeProductId)
        {
            return await _fridgeProductsRepository.IsExistAsync(fridgeProductId);
        }

        public async Task<bool> IsExistFridgeProductAsync(FridgeProductDto fridgeProduct)
        {
            var fridgeProductMap = _mapper.Map<FridgeProductEntity>(fridgeProduct);

            return await _fridgeProductsRepository.IsExistFridgeProductAsync(fridgeProductMap);
        }

        public async Task<bool> IsExistFridgeAsync(Guid fridgeId)
        {
            return await _fridgeProductsRepository.IsExistFridgeAsync(fridgeId);
        }
    }
}
