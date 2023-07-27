using Newtonsoft.Json;
using Basket.Host.Model.Dto;
using Basket.Host.Service.IService;

namespace Basket.Host.Service
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }
        public async Task<ProductDto> GetProductById(int productId)
        {
            var client = _httpClientFactory.CreateClient("Catalog");
            var response = await client.GetAsync($"/api/catalog/{productId}");
            var apiContent = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
            if (resp.Success)
            {
                return JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(resp.Result));
            }
            return null; 
        }
    }
}
