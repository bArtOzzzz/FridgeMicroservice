using AutoMapper;
using FridgeMicroservice.Models.Request;
using FridgeMicroservice.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using Services.Dto;

namespace FridgeMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : Controller
    {
        private readonly IModelsService _modelsService;
        private readonly IMapper _mapper;

        public ModelsController(IModelsService modelsService,
                                IMapper mapper)
        {
            _modelsService = modelsService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> GetAllAsync()
        {
            if (!ModelState.IsValid)
                return NotFound();

            var models = await _modelsService.GetAllAsync();

            return Ok(_mapper.Map<List<ModelResponse>>(models));
        }

        [HttpGet("{modelId}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> GetByIdAsync(Guid modelId)
        {
            bool isExist = await _modelsService.IsExist(modelId);

            if (!isExist || !ModelState.IsValid)
                return NotFound();

            var model = await _modelsService.GetByIdAsync(modelId);

            return Ok(_mapper.Map<ModelResponse>(model));
        }

        [HttpPost]
        [Authorize(Roles = "User, Administrator")]
        public async Task<ActionResult> CreateAsync(ModelModel model)
        {
            if (model == null || !ModelState.IsValid)
                return NotFound();

            var modelMap = _mapper.Map<ModelDto>(model);

            Guid modelId;

            if (modelMap != null)
                modelId = await _modelsService.CreateAsync(modelMap);
            else
                return NotFound();

            return Ok(modelId);
        }

        [HttpPut("{modelId}")]
        [Authorize(Roles = "User, Administrator")]
        public async Task<ActionResult> UpdateAsync(Guid modelId, ModelModel model)
        {
            bool isExist = await _modelsService.IsExist(modelId);

            if (!isExist || model == null || !ModelState.IsValid)
                return NotFound();

            var modelMap = _mapper.Map<ModelDto>(model);

            if (modelMap != null)
                await _modelsService.UpdateAsync(modelId, modelMap);

            return Ok(modelId);
        }

        [HttpDelete("{modelId}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> DeleteAsync(Guid modelId)
        {
            bool isExist = await _modelsService.IsExist(modelId);

            if (!isExist || !ModelState.IsValid)
                return NotFound();

            Task<ModelDto> modelToDelete = _modelsService.GetByIdAsync(modelId)!;

            if (await _modelsService.DeleteAsync(await modelToDelete) == false)
            {
                ModelState.AddModelError("", "Something went wrong deleting model");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
