using AutoMapper;
using Basket.Host.Data;
using Microsoft.AspNetCore.Mvc;
using Order.Host.Model.Dto;
using Order.Host.Models.Dto;
using Order.Host.Service.IService;

namespace Order.Host.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderApiController : ControllerBase
    {
        private ResponseDto _responseDto;
        private IMapper _mapper;
        private readonly IBasketService _basketService;
        private readonly ApplicationDbContext _db;

        public OrderApiController(IMapper mapper, ApplicationDbContext db, IBasketService basketService)
        {
            _db = db;
            this._responseDto = new ResponseDto();
            _mapper = mapper;
            _basketService = basketService;
        }

        [HttpPost("CreateOrder/{userId}")]
        public async Task<IActionResult> CreateOrder(string userId)
        {
            try
            {
                var basketDto = await _basketService.GetBasket(userId);
                var firstItem = basketDto.Items.First();
                var newOrder = new Models.Order
                {
                    BasketId = basketDto.BasketId,
                    UserId = userId,
                    Price = firstItem.Product?.Price ?? 0
                };

                _db.Orders.Add(newOrder);
                _db.SaveChanges();
                var createdOrderDto = _mapper.Map<OrderDto>(newOrder);
                _responseDto.Result = createdOrderDto;
            }
            catch (Exception ex)
            {
                _responseDto.Success = false;
                _responseDto.Messenge = ex.Message;

            }
            return Ok(_responseDto);
        }

        [HttpDelete("delete/{orderId}")]
        public IActionResult DeleteOrder(int orderId)
        {
            try
            {
                var order = _db.Orders.Find(orderId);

                _db.Orders.Remove(order);
                _db.SaveChanges();
                var orderDto = _mapper.Map<OrderDto>(order);
                _responseDto.Result = orderDto;
            }
            catch (Exception ex)
            {
                _responseDto.Success = false;
                _responseDto.Messenge = ex.Message;
            }
            return Ok(_responseDto);
        }

    }
}
