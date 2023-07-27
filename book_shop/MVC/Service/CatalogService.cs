using MVC.Models;
using MVC.Service.IService;
using MVC.Utility;
using static System.Net.WebRequestMethods;

namespace MVC.Service
{
    public class CatalogService : ICatalogService
    {
        private readonly IBaseService _baseService;

        public CatalogService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> GetAllProductsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CatalogApiBase + "/api/catalog/"
            });
        }

        public async Task<ResponseDto?> GetProductAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CatalogApiBase + "/api/catalog/" + id
            });
        }
    }
}
