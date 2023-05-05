using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Webshop.API.Models.Dto;
using Webshop.API.Models.Entities;

namespace Webshop.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductEntity, ProductDto>();
            CreateMap<ProductRatingEntity, ProductRatingDto>();
            CreateMap<AddProductDto, ProductEntity>();
            CreateMap<AddProductRatingDto, ProductRatingEntity>();
            CreateMap<ShowcaseEntity, ShowcaseDto>();
			CreateMap<ProductEntity, ProductDto>();
		}
    }
}
