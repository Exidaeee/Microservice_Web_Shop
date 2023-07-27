using Basket.Host.Model.Dto;

namespace Basket.Host.Service.IService
{
    public interface IProductService
    {
        Task<ProductDto> GetProductById(int productId);
    }
}
