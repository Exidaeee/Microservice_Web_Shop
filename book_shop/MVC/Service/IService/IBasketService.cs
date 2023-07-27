using MVC.Models;

namespace MVC.Service.IService
{
    public interface IBasketService
    {
        Task<ResponseDto> GetBasketAsync(string userId);
        Task<ResponseDto> CreateBasketAsync(string userId, BasketItemDto item);
        Task<ResponseDto> UpdateBasketAsync(string userId, BasketItemDto item);
        Task<ResponseDto> DeleteBasketAsync(string userId);
    }
}
