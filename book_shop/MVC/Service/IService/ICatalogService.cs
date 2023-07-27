using MVC.Models;

namespace MVC.Service.IService
{
    public interface ICatalogService
    {
        Task<ResponseDto?> GetAllProductsAsync();
        Task<ResponseDto?> GetProductAsync(int id);
    }
}
