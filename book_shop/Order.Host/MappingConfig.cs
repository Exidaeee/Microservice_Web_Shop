using AutoMapper;
using Order.Host.Models.Dto;

namespace Basket.Host
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Order.Host.Models.Order, OrderDto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
