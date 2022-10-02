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
    public class FridgeProductsController : Controller
    {
        private readonly IFridgeProductsService _fridgeProductsService;
        private readonly IMapper _mapper;

        public FridgeProductsController(IFridgeProductsService fridgeProductsService,
                                        IMapper mapper)
        {
            _fridgeProductsService = fridgeProductsService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "User, Administrator")]
        public async Task<ActionResult> GetAllAsync()
        {
            if (!ModelState.IsValid)
                return NotFound();

            var fridgeProducts = await _fridgeProductsService.GetAllAsync();

            return Ok(_mapper.Map<List<FridgeProductResponse>>(fridgeProducts));
        }

        [HttpGet("{FridgeProductId}")]
        [Authorize(Roles = "User, Administrator")]
        public async Task<ActionResult> GetByIdAsync(Guid FridgeProductId)
        {
            bool isExist = await _fridgeProductsService.IsExistAsync(FridgeProductId);

            if (!isExist || ModelState.IsValid)
                return NotFound();

            var fidgeProduct = await _fridgeProductsService.GetByIdAsync(FridgeProductId);

            return Ok(_mapper.Map<FridgeProductResponse>(fidgeProduct));
        }

        [HttpGet("fridgeProduct/{fridgeId}")]
        // TODO: Auth comment!
        //[Authorize(Roles = "User, Administrator")]
        public async Task<ActionResult> GetFridgeProductsByFridgeIdAsync(Guid fridgeId)
        {
            bool isExist = await _fridgeProductsService.IsExistFridgeAsync(fridgeId);

            if (!isExist || !ModelState.IsValid)
                return NotFound();

            var fridgeProduct = await _fridgeProductsService.GetFridgeProductsByFridgeIdAsync(fridgeId);

            return Ok(_mapper.Map<List<FridgeProductResponse>>(fridgeProduct));
        }

        [HttpPut("{fridgeProductId}")]
        [Authorize(Roles = "User, Administrator")]
        public async Task<ActionResult> UpdateAsync(Guid fridgeProductId, FridgeProductModelUpdate fridgeProduct)
        {
            bool isExist = await _fridgeProductsService.IsExistAsync(fridgeProductId);

            if (!isExist || fridgeProduct == null || !ModelState.IsValid)
                return NotFound();

            var fridgeProductMap = _mapper.Map<FridgeProductDto>(fridgeProduct);

            if (fridgeProductMap != null)
                await _fridgeProductsService.UpdateAsync(fridgeProductId, fridgeProductMap);

            return Ok(fridgeProductId);
        }

        [HttpPost("{fridgeId}")]
        [Authorize(Roles = "User, Administrator")]
        public async Task<ActionResult> CreateAsync(Guid id, FridgeProductModelCreate fridgeProduct)
        {
            if (fridgeProduct == null || !ModelState.IsValid)
                return NotFound();

            var productMap = _mapper.Map<FridgeProductDto>(fridgeProduct);

            if (productMap != null)
                await _fridgeProductsService.CreateAsync(id, productMap);
            else
                return BadRequest("Invalid data");

            string[] response = new[]
            {
                id.ToString(),
                productMap.Id.ToString(),
                productMap.ProductId.ToString()
            };

            return Ok(response);
        }

        [HttpDelete("{FridgeProductId}")]
        [Authorize(Roles = "User, Administrator")]
        public async Task<ActionResult> DeleteAsync(Guid FridgeProductId)
        {
            bool isExist = await _fridgeProductsService.IsExistAsync(FridgeProductId);

            if (!isExist || !ModelState.IsValid)
                return NotFound();

            Task<FridgeProductDto> fridgeProductToDelete = _fridgeProductsService.GetByIdAsync(FridgeProductId)!;

            if (await _fridgeProductsService.DeleteAsync(await fridgeProductToDelete) == false)
            {
                ModelState.AddModelError("", "Something went wrong deleting model");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
