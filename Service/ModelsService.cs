using AutoMapper;
using Repositories.Abstract;
using Repositories.Entities;
using Services.Abstract;
using Services.Dto;

namespace Services
{
    public class ModelsService : IModelsService
    {
        private readonly IModelsRepository _modelsRepository;
        private readonly IMapper _mapper;

        public ModelsService(IModelsRepository modelsRepository,
                             IMapper mapper)
        {
            _modelsRepository = modelsRepository;
            _mapper = mapper;
        }

        // GET
        public async Task<List<ModelDto>> GetAllAsync()
        {
            var models = await _modelsRepository.GetAllAsync();

            return _mapper.Map<List<ModelDto>>(models);
        }

        public async Task<ModelDto?> GetByIdAsync(Guid id)
        {
            var model = await _modelsRepository.GetByIdAsync(id);

            return _mapper.Map<ModelDto>(model);
        }

        // POST
        public async Task<Guid> CreateAsync(ModelDto model)
        {
            var modelMap = _mapper.Map<ModelEntity>(model);

            await _modelsRepository.CreateAsync(modelMap);
            model.Id = modelMap.Id;

            return modelMap.Id;
        }

        // PUT
        public async Task<Guid> UpdateAsync(Guid modelId, ModelDto model)
        {
            var modelMap = _mapper.Map<ModelEntity>(model);

            return await _modelsRepository.UpdateAsync(modelId, modelMap);
        }

        //DELETE
        public async Task<bool> DeleteAsync(ModelDto model)
        {
            var modelMap = _mapper.Map<ModelEntity>(model);

            return await _modelsRepository.DeleteAsync(modelMap);
        }

        // EXISTS
        public async Task<bool> IsExist(Guid id)
        {
            return await _modelsRepository.IsExist(id);
        }
    }
}
