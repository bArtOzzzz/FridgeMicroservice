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
    public class FridgesController : Controller
    {
        private readonly IFridgesService _fridgesService;
        private readonly IMapper _mapper;

        public FridgesController(IFridgesService fridgesService,
                                 IMapper mapper)
        {
            _fridgesService = fridgesService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "User, Administrator")]
        public async Task<ActionResult> GetAllAsync()
        {
            if (!ModelState.IsValid)
                return NotFound();

            var fridges = await _fridgesService.GetAllAsync();

            return Ok(_mapper.Map<List<FridgeResponse>>(fridges));
        }

        [HttpGet("{fridgeId}")]
        [Authorize(Roles = "User, Administrator")]
        public async Task<ActionResult> GetByIdAsync(Guid fridgeId)
        {
            bool isExist = await _fridgesService.IsExistAsync(fridgeId);

            if (!isExist || !ModelState.IsValid)
                return NotFound();

            var fridges = await _fridgesService.GetByIdAsync(fridgeId);

            return Ok(_mapper.Map<List<FridgeResponse>>(fridges));
        }

        [HttpGet("products/{fridgeId}")]
        [Authorize(Roles = "User, Administrator")]
        public async Task<ActionResult> GetProductsByFridgeIdAsync(Guid fridgeId)
        {
            bool isExist = await _fridgesService.IsExistAsync(fridgeId);

            if (!isExist || !ModelState.IsValid)
                return NotFound();

            var products = await _fridgesService.GetProductsByFridgeIdAsync(fridgeId);

            return Ok(_mapper.Map<List<ProductResponse>>(products));
        }

        [HttpPost]
        [Authorize(Roles = "User, Administrator")]
        public async Task<ActionResult> CreateAsync(FridgeModel fridge)
        {
            if (fridge == null || !ModelState.IsValid)
                return NotFound();

            var fridgeMap = _mapper.Map<FridgeDto>(fridge);

            Guid fridgeId;

            if (fridgeMap != null)
                fridgeId = await _fridgesService.CreateAsync(fridgeMap);
            else
                return NotFound();

            return Ok(fridgeId);
        }

        [HttpPut("{fridgeId}")]
        [Authorize(Roles = "User, Administrator")]
        public async Task<ActionResult> UpdateAsync(Guid fridgeId, FridgeModel fridge)
        {
            bool isExist = await _fridgesService.IsExistAsync(fridgeId);

            if (!isExist || fridge == null || !ModelState.IsValid)
                return NotFound();

            var fridgeMap = _mapper.Map<FridgeDto>(fridge);

            if (fridgeMap != null)
                await _fridgesService.UpdateAsync(fridgeId, fridgeMap);

            return Ok(fridgeId);
        }

        [HttpDelete("{fridgeId}")]
        [Authorize(Roles = "User, Administrator")]
        public async Task<ActionResult> DeleteAsync(Guid fridgeId)
        {
            bool isExist = await _fridgesService.IsExistAsync(fridgeId);

            if (!isExist || !ModelState.IsValid)
                return NotFound();

            Task<FridgeDto> modelToDelete = _fridgesService.GetByIdAsync(fridgeId)!;

            if (await _fridgesService.DeleteAsync(await modelToDelete) == false)
            {
                ModelState.AddModelError("", "Something went wrong deleting fridge");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
