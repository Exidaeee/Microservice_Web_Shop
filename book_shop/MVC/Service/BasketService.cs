using MVC.Models;
using MVC.Service.IService;
using MVC.Utility;

namespace MVC.Service
{
    public class BasketService : IBasketService
    {
        private readonly IBaseService _baseService;


        public BasketService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto> CreateBasketAsync(string userId, BasketItemDto item)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.POST,
                Data = item,
                Url = SD.BasketApiBase + "/api/basket/CreateBasket/" + userId
            });
        }

        public async Task<ResponseDto> DeleteBasketAsync(string userId)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.BasketApiBase + "/api/basket/DeleteBasket/" + userId
            }); ;
        }

        public async Task<ResponseDto> GetBasketAsync(string userId)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.BasketApiBase + "/api/basket/GetBasket/" + userId
            });
        }

        public async Task<ResponseDto> UpdateBasketAsync(string userId, BasketItemDto item)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.PUT,
                Data = item,
                Url = SD.BasketApiBase + "/api/basket/UpdateBasket/" + userId
            });
        }
    }
}
