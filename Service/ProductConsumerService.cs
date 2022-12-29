using Microsoft.Extensions.Hosting;
using Microsoft.Azure.ServiceBus;
using Services.Abstract;
using Newtonsoft.Json;
using Services.Dto;
using MassTransit;
using System.Text;

namespace Service
{
    public class ProductConsumerService : IConsumer<ProductDto>
    {
        private readonly IProductsService _productService;

        public ProductConsumerService(IProductsService productService) => _productService = productService;

        public async Task Consume(ConsumeContext<ProductDto> context)
        {
            if (context.Message.CrudOperationsInfo.Equals(CrudOperationsInfo.Create))
            {
                await _productService.CreateAsync(context.Message);
            }
            else if (context.Message.CrudOperationsInfo.Equals(CrudOperationsInfo.Update))
            {
                await _productService.UpdateAsync(context.Message, context.Message.Name!);
            }
            else if (context.Message.CrudOperationsInfo.Equals(CrudOperationsInfo.Delete))
            {
                await _productService.DeleteAsync(context.Message);
            }
        }
    }
}
