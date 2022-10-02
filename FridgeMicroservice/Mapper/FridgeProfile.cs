using AutoMapper;
using FridgeMicroservice.Models.Request;
using FridgeMicroservice.Models.Response;
using Repositories.Entities;
using Services.Dto;

namespace FridgeMicroservice.Mapper
{
    public class FridgeProfile : Profile
    {
        public FridgeProfile()
        {
            CreateMap<FridgeDto, FridgeResponse>();
            CreateMap<FridgeResponse, FridgeDto>();

            CreateMap<ModelDto, ModelResponse>();
            CreateMap<ModelResponse, ModelDto>();

            CreateMap<FridgeModel, FridgeDto>();
            CreateMap<FridgeDto, FridgeModel>();

            CreateMap<ModelModel, ModelDto>();
            CreateMap<ModelDto, ModelModel>();

            CreateMap<FridgeEntity, FridgeDto>();
            CreateMap<FridgeDto, FridgeEntity>();

            CreateMap<ModelEntity, ModelDto>();
            CreateMap<ModelDto, ModelEntity>();
        }
    }
}
