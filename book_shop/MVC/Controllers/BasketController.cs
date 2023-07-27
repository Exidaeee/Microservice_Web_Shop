using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using MVC.Models;
using MVC.Service.IService;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly ICatalogService _catalogService;
        public BasketController(IBasketService basketService, ICatalogService catalogService)
        {
            _basketService = basketService;
            _catalogService = catalogService;
        }

        [Authorize]
        public async Task<IActionResult> BasketIndex()
        {
            var userId = User.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub)?.Value;
            ResponseDto response = await _basketService.GetBasketAsync(userId);

            if (response != null && response.Success)
            {
                var basketDto = JsonConvert.DeserializeObject<BasketDto>(Convert.ToString(response.Result));
                return View(basketDto);
            }

            return View(new BasketDto());
        }


        [Authorize]
        public async Task<IActionResult> AddToBasket(int id)
        {
            ProductDto? model = new();
            ResponseDto productResponse = await _catalogService.GetProductAsync(id);
            model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(productResponse.Result));
            BasketItemDto item = new() { ProductId = id, Product = model };
            var userId = User.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub)?.Value;
            var response = await _basketService.GetBasketAsync(userId);

            if (response != null && response.Success && response.Result != null)
            {
                response = await _basketService.UpdateBasketAsync(userId, item);
            }
            else
            {
                response = await _basketService.CreateBasketAsync(userId, item);
            }

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public async Task<IActionResult> DeleteBasket()
        {
            var userId = User.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub)?.Value;
            ResponseDto response = await _basketService.DeleteBasketAsync(userId);
            return RedirectToAction("Index", "Home");
        }
    }
}
