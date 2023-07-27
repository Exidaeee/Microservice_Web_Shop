using Moq;
using Newtonsoft.Json;
using Order.Host.Model.Dto;
using Order.Host.Service;

namespace Order.Tests
{
    public class BasketServiceTests
    {
        [Fact]
        public async Task GetBasket_ValidUserId_ReturnsBasketDto()
        {
            // Arrange
            var userId = "valid_user_id";
            var basketItemDto = new BasketItemDto
            {
                BasketItemId = 1,
                ProductId = 101,
                Product = new ProductDto
                {
                    ProductId = 101,
                    Title = "Product 1",
                    Price = 100
                    // Add other product properties as needed.
                }
            };

            var basketDto = new BasketDto
            {
                BasketId = 1,
                UserId = userId,
                CreatedAt = DateTime.UtcNow,
                Items = new List<BasketItemDto> { basketItemDto }
            };

            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            var httpClientMock = new Mock<HttpClient>();
            var httpResponseMock = new Mock<HttpResponseMessage>();

            httpResponseMock.Setup(response => response.Content.ReadAsStringAsync())
                            .ReturnsAsync(JsonConvert.SerializeObject(new ResponseDto
                            {
                                Success = true,
                                Result = JsonConvert.SerializeObject(basketDto)
                            }));

            httpClientMock.Setup(client => client.GetAsync(It.IsAny<string>()))
                          .ReturnsAsync(httpResponseMock.Object);

            httpClientFactoryMock.Setup(factory => factory.CreateClient("Basket"))
                                 .Returns(httpClientMock.Object);

            var basketService = new BasketService(httpClientFactoryMock.Object);

            // Act
            var result = await basketService.GetBasket(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.BasketId);
            Assert.Equal(userId, result.UserId);
            Assert.NotEmpty(result.Items);
            Assert.Equal(1, result.Items.Count);
            Assert.Equal(101, result.Items.First().ProductId);
        }

        [Fact]
        public async Task GetBasket_InvalidUserId_ReturnsEmptyBasketDto()
        {
            // Arrange
            var userId = "invalid_user_id";

            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            var httpClientMock = new Mock<HttpClient>();
            var httpResponseMock = new Mock<HttpResponseMessage>();

            httpResponseMock.Setup(response => response.Content.ReadAsStringAsync())
                            .ReturnsAsync(JsonConvert.SerializeObject(new ResponseDto
                            {
                                Success = false,
                                Result = null 
                            }));

            httpClientMock.Setup(client => client.GetAsync(It.IsAny<string>()))
                          .ReturnsAsync(httpResponseMock.Object);

            httpClientFactoryMock.Setup(factory => factory.CreateClient("Basket"))
                                 .Returns(httpClientMock.Object);

            var basketService = new BasketService(httpClientFactoryMock.Object);

            // Act
            var result = await basketService.GetBasket(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result.Items);
        }
    }
}