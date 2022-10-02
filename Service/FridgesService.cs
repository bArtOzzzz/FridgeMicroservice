using AutoMapper;
using Repositories.Abstract;
using Repositories.Entities;
using Services.Abstract;
using Services.Dto;

namespace Services
{
    public class FridgesService : IFridgesService
    {
        private readonly IFridgesRepository _fridgesRepository;
        private readonly IMapper _mapper;

        public FridgesService(IFridgesRepository fridgesRepository,
                              IMapper mapper)
        {
            _fridgesRepository = fridgesRepository;
            _mapper = mapper;
        }

        // GET
        public async Task<List<FridgeDto>> GetAllAsync()
        {
            var fridges = await _fridgesRepository.GetAllAsync();

            return _mapper.Map<List<FridgeDto>>(fridges);
        }

        public async Task<FridgeDto?> GetByIdAsync(Guid id)
        {
            var fridge = await _fridgesRepository.GetByIdAsync(id);

            return _mapper.Map<FridgeDto>(fridge);
        }

        public async Task<List<ProductDto>> GetProductsByFridgeIdAsync(Guid fridgeId)
        {
            var productsByFridge = await _fridgesRepository.GetProductsByFridgeIdAsync(fridgeId);

            return _mapper.Map<List<ProductDto>>(productsByFridge);
        }

        // POST
        public async Task<Guid> CreateAsync(FridgeDto fridge)
        {
            var fridgeMap = _mapper.Map<FridgeEntity>(fridge);

            await _fridgesRepository.CreateAsync(fridgeMap);
            fridge.Id = fridgeMap.Id;

            return fridgeMap.Id;
        }

        // PUT
        public async Task<Guid> UpdateAsync(Guid fridgeId, FridgeDto fridge)
        {
            var fridgeMap = _mapper.Map<FridgeEntity>(fridge);

            return await _fridgesRepository.UpdateAsync(fridgeId, fridgeMap);
        }

        //DELETE
        public async Task<bool> DeleteAsync(FridgeDto fridge)
        {
            var fridgeMap = _mapper.Map<FridgeEntity>(fridge);

            return await _fridgesRepository.DeleteAsync(fridgeMap);
        }

        //EXISTS
        public async Task<bool> IsExistAsync(Guid id)
        {
            return await _fridgesRepository.IsExistAsync(id);
        }
    }
}
