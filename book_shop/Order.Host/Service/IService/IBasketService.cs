using Order.Host.Model.Dto;

namespace Order.Host.Service.IService
{
    public interface IBasketService
    {
        Task<BasketDto> GetBasket(string userId);
    }
}
