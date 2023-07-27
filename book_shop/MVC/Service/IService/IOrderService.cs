using MVC.Models;

namespace MVC.Service.IService
{
    public interface IOrderService
    {
        Task<ResponseDto> CreateOrdetAsync(string userId);
    }
}
