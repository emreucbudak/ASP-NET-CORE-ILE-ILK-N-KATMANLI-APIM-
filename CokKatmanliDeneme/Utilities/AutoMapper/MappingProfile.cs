using AutoMapper;
using DTOLAR;
using Entities.Dto;
using Entities.Models;

namespace CokKatmanliDeneme.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDtoForUpdate,Product>();
            CreateMap<ProductDto, Product>();
        }
    }
}
