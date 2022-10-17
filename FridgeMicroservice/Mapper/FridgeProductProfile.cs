using FridgeMicroservice.Models.Response;
using FridgeMicroservice.Models.Request;
using Repositories.Entities;
using Services.Dto;
using AutoMapper;

namespace FridgeMicroservice.Mapper
{
    public class FridgeProductProfile : Profile
    {
        public FridgeProductProfile()
        {
            CreateMap<FridgeProductDto, FridgeProductResponse>();
            CreateMap<FridgeProductResponse, FridgeProductDto>();

            CreateMap<FridgeProductModelCreate, FridgeProductDto>();
            CreateMap<FridgeProductDto, FridgeProductModelCreate>();

            CreateMap<FridgeProductModelUpdate, FridgeProductDto>();
            CreateMap<FridgeProductDto, FridgeProductModelUpdate>();

            CreateMap<FridgeProductModelUpdate, FridgeProductDto>();
            CreateMap<FridgeProductDto, FridgeProductModelUpdate>();

            CreateMap<FridgeProductEntity, FridgeProductDto>();
            CreateMap<FridgeProductDto, FridgeProductEntity>();
        }
    }
}
