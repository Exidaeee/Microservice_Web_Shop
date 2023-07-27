using MVC.Models;
using MVC.Service.IService;
using MVC.Utility;

namespace MVC.Service
{
    public class OrderService : IOrderService
    {
        private readonly IBaseService _baseService;

        public OrderService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto> CreateOrdetAsync(string userId)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.POST,
                Url = SD.OrderApiBase + "/api/order/CreateOrder/" + userId
            });
        }
    }
}
