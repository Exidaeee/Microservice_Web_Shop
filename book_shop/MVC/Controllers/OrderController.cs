using Microsoft.AspNetCore.Mvc;
using MVC.Service.IService;
using System.IdentityModel.Tokens.Jwt;

namespace MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;        
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<IActionResult> Index()
        {
            var userId = User.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub)?.Value;
            var responseDto = await _orderService.CreateOrdetAsync(userId);
            return View();
        }
    }
}
