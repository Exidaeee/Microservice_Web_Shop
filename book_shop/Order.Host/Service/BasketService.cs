using Newtonsoft.Json;
using Order.Host.Model.Dto;
using Order.Host.Service.IService;

namespace Order.Host.Service
{
    public class BasketService : IBasketService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasketService(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }
        public async Task<BasketDto> GetBasket(string userId)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("Basket");
                var response = await client.GetAsync($"/api/basket/GetBasket/" + userId);
                var apiContet = await response.Content.ReadAsStringAsync();
                var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContet);
                Console.WriteLine(resp.Result);
                if (resp.Success)
                {
                    return JsonConvert.DeserializeObject<BasketDto>(Convert.ToString(resp.Result));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetBasket: " + ex.Message);
            }
            return new BasketDto();
        }
    }
}
