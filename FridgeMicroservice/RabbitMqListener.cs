using Services.Abstract;
using Services.Dto;
using MassTransit;

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
            if(context.Message.CrudOperationsInfo.Equals(CrudOperationsInfo.Create))
            {
                await _productService.CreateAsync(context.Message);
            }
            else if (context.Message.CrudOperationsInfo.Equals(CrudOperationsInfo.Update))
            {
                await _productService.UpdateAsync(context.Message, context.Message.Name); 
            }
            else if (context.Message.CrudOperationsInfo.Equals(CrudOperationsInfo.Delete))
            {
                await _productService.DeleteAsync(context.Message);
            }
        }
    }
}
