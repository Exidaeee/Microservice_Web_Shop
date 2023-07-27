using AutoMapper;
using Basket.Host.Data;
using Basket.Host.Model;
using Basket.Host.Model.Dto;
using Basket.Host.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Basket.Host.Controllers
{
    [ApiController]
    [Route("api/basket")]
    public class BasketApiController : ControllerBase
    {
        private ResponseDto _responseDto;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public BasketApiController(ApplicationDbContext db, IMapper mapper, IProductService productService)
        {
            _db = db;
            this._responseDto = new ResponseDto();
            _mapper = mapper;
            _productService = productService;
        }

        [HttpPost("CreateBasket/{userId}")]
        public async Task<IActionResult> CreateBasket(string userId, [FromBody]BasketItemDto item)
        {
            try
            {
                var newBasket = new Model.Basket
                {
                    UserId = userId,
                    CreatedAt = DateTime.Now,
                    Items = new List<BasketItem>()
                };
                var productDto = await _productService.GetProductById(item.ProductId);
                var basketItem = new BasketItem
                {
                    ProductId = item.ProductId,
                    Product = _mapper.Map<Product>(productDto)

                };             
               
                newBasket.Items.Add(basketItem);
                _db.Baskets.Add(newBasket);
                _db.SaveChanges();

                var basketDto = _mapper.Map<BasketDto>(newBasket);              
                _responseDto.Result = basketDto;
            }
            catch (Exception ex)
            {
                _responseDto.Success = false;
                _responseDto.Messenge = ex.Message;
            }
            return Ok(_responseDto);
        }

        [HttpGet("GetBasket/{userId}")]
        public IActionResult GetBasket(string userId)
        {
            try
            {
                var basket = _db.Baskets
                .Include(b => b.Items)
                .ThenInclude(item => item.Product)
                .FirstOrDefault(b => b.UserId == userId);
                var basketDto = (basket != null) ? _mapper.Map<BasketDto>(basket) : null;
                _responseDto.Result = basketDto;
            }
            catch (Exception ex)
            {
                _responseDto.Success=false;
                _responseDto.Messenge = ex.Message;
                
            }
            return Ok(_responseDto);
        }

        [HttpDelete("DeleteBasket/{userId}")]
        public IActionResult DeleteBasket(string userId)
        {
            try
            {
                var basket = _db.Baskets
                    .Include(b => b.Items)
                    .FirstOrDefault(b => b.UserId == userId);

                _db.Baskets.Remove(basket);
                _db.SaveChanges();

                var basketDto = _mapper.Map<BasketDto>(basket);
                _responseDto.Result=basketDto;
            }
            catch(Exception ex)
            {
                _responseDto.Success = false;
                _responseDto.Messenge = ex.Message;           
            }
            return Ok(_responseDto);
        }
        [HttpPut("UpdateBasket/{userId}")]
        public async Task<IActionResult> UpdateBasket(string userId, [FromBody]BasketItemDto item)
        {
            try
            {
                var basket = _db.Baskets
               .Include(b => b.Items)
               .FirstOrDefault(b => b.UserId == userId);
                basket.Items.Clear();
                var productDto = await _productService.GetProductById(item.ProductId);
                var basketItem = new BasketItem
                {
                    ProductId = item.ProductId,
                    Product = _mapper.Map<Product>(productDto)
                };
                    basket.Items.Add(basketItem);               
                _db.SaveChanges();
                var basketDto = _mapper.Map<BasketDto>(basket);
                _responseDto.Result = basketDto;
            }
            catch (Exception ex)
            {
                _responseDto.Success = false;
                _responseDto.Messenge =ex.Message;
            }
            return Ok(_responseDto);
        }
    }

}
