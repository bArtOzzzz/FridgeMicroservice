using FridgeMicroservice.Models.Response;
using Repositories.Entities;
using Services.Dto;
using AutoMapper;

namespace FridgeMicroservice.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, ProductResponse>();
            CreateMap<ProductResponse, ProductDto>();

            CreateMap<ProductEntity, ProductDto>();
            CreateMap<ProductDto, ProductEntity>();
        }
    }
}
