using AutoMapper;
using Basket.Host.Model;
using Basket.Host.Model.Dto;

namespace Basket.Host
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Model.Basket, BasketDto>().ReverseMap();
                config.CreateMap<BasketItem, BasketItemDto>().ReverseMap();
                config.CreateMap<Product, ProductDto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
