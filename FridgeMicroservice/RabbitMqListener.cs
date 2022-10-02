using MassTransit;
using Services.Abstract;
using Services.Dto;

namespace Service
{
    public class RabbitMqListener : IConsumer<ProductDto>
    {
        private readonly IProductsService _productService;

        public RabbitMqListener(IProductsService productService)
        {
            _productService = productService;
        }

        public async Task Consume(ConsumeContext<ProductDto> context)
        {
            // Create fridge: works
            if(context.Message.CrudOperationsInfo.Equals(CrudOperationsInfo.Create))
            {
                await _productService.CreateAsync(context.Message);
            }
            // TODO: FIXED
            else if (context.Message.CrudOperationsInfo.Equals(CrudOperationsInfo.Update))
            {
                // Name - Новое имя (обновленное) или текущее
                await _productService.UpdateAsync(context.Message, context.Message.Name); 
            }
            // Delete fridge: works
            else if (context.Message.CrudOperationsInfo.Equals(CrudOperationsInfo.Delete))
            {
                await _productService.DeleteAsync(context.Message);
            }
        }
    }
}
