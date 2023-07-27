using System.Net;
using Basket.Host.Model.Dto;
using Basket.Host.Service;
using FluentAssertions;
using Moq;
using Newtonsoft.Json;

namespace Basket.Tests
{
    public class ProductServiceTests
    {
        [Fact]
        public async Task GetProductById_WhenValidResponse_ReturnsProductDto()
        {
            // Arrange
            var productId = 1;
            var productDto = new ProductDto
            {
                ProductId = productId,
                Title = "Test Product",
                Price = 100
            };

            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            var httpClientMock = new Mock<HttpClient>();

            // Настройка ответа от HttpClient
            httpClientMock.Setup(_ => _.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(new ResponseDto
                    {
                        Success = true,
                        Result = JsonConvert.SerializeObject(productDto)
                    }))
                });

            httpClientFactoryMock.Setup(_ => _.CreateClient(It.IsAny<string>()))
                .Returns(httpClientMock.Object);

            var productService = new ProductService(httpClientFactoryMock.Object);

            // Act
            var result = await productService.GetProductById(productId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(productDto);
        }

        [Fact]
        public async Task GetProductById_WhenErrorResponse_ReturnsNull()
        {
            // Arrange
            var productId = 1;

            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            var httpClientMock = new Mock<HttpClient>();
            httpClientFactoryMock.Setup(_ => _.CreateClient("Catalog")).Returns(httpClientMock.Object);
            httpClientMock.Setup(_ => _.GetAsync($"/api/catalog/{productId}"))
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent(JsonConvert.SerializeObject(new ResponseDto
                    {
                        Success = false,
                        Messenge = "Bad Request"
                    }))
                });

            var productService = new ProductService(httpClientFactoryMock.Object);

            // Act
            var result = await productService.GetProductById(productId);

            // Assert
            Assert.Null(result);
        }
    }
}
