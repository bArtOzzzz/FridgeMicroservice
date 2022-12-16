using FridgeMicroservice.Models.Response;
using Microsoft.AspNetCore.Authorization;
using FridgeMicroservice.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using Services.Dto;
using AutoMapper;

namespace FridgeMicroservice.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
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
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> GetAllAsync()
        {
            if (!ModelState.IsValid)
                return NotFound();

            var fridgeProducts = await _fridgeProductsService.GetAllAsync();

            return Ok(_mapper.Map<List<FridgeProductResponse>>(fridgeProducts));
        }

        [HttpGet("{FridgeProductId}")]
        [Authorize(Roles = "User, Administrator")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> GetByIdAsync(Guid FridgeProductId)
        {
            bool isExist = await _fridgeProductsService.IsExistAsync(FridgeProductId);

            if (!isExist || ModelState.IsValid)
                return NotFound();

            var fidgeProduct = await _fridgeProductsService.GetByIdAsync(FridgeProductId);

            return Ok(_mapper.Map<FridgeProductResponse>(fidgeProduct));
        }

        [HttpGet("fridgeProduct/{fridgeId}")]
        [Authorize(Roles = "User, Administrator")]
        [MapToApiVersion("1.0")]
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
        [MapToApiVersion("1.0")]
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
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> CreateAsync(Guid fridgeId, FridgeProductModelCreate fridgeProduct)
        {
            if (fridgeProduct == null || !ModelState.IsValid)
                return NotFound();

            var productMap = _mapper.Map<FridgeProductDto>(fridgeProduct);
            productMap.FridgeId= fridgeId;

            bool isExist = await _fridgeProductsService.IsExistFridgeProductAsync(productMap);

            if (productMap == null)
                return NotFound("Invalid data or resource not found");

            if (!isExist)
                await _fridgeProductsService.CreateAsync(fridgeId, productMap);
            else
                return BadRequest("The same resourse already exist!");

            string[] response = new[]
            {
                fridgeId.ToString(),
                productMap.Id.ToString(),
                productMap.ProductId.ToString()
            };

            return Ok(response);
        }

        [HttpDelete("{FridgeProductId}")]
        [Authorize(Roles = "User, Administrator")]
        [MapToApiVersion("1.0")]
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
