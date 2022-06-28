using Moq;
using ShopOnline.Api.Controllers;
using ShopOnline.Api.Entities;
using ShopOnline.Api.Extensions;
using ShopOnline.Api.Repositories.Contracts;
using ShopOnline.Models.Dtos;
using ShopOnline.Api.IntegrationTests.ClassData.ShoppingCartController;

namespace ShopOnline.Api.IntegrationTests.Tests
{
    public class ShoppingCarttController : IClassFixture<WebApplicationFactory<Program>>
    {

        private HttpClient _httpClient;

        public ShoppingCarttController(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async void GetItems_WithUserIdWhichExist_ReturnsOkResult(int userId)
        {
            //act
            var response = await _httpClient.GetAsync($"api/ShoppingCart/{userId}/GetItems");

            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Theory]
        [InlineData(1050)]
        [InlineData(2000)]
        public async void GetItems_WithUserIdWhichNoExist_ReturnsOkResult(int userId)
        {
            //act
            var response = await _httpClient.GetAsync($"api/ShoppingCart/{userId}/GetItems");

            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }


        [Theory]
        [ClassData(typeof(PostItemData))]
        public async void PostItem_WithCartItemToAddDto_ReturnsCartItemDto(
                    CartItemToAddDto cartItemToAddDto,
                    CartItem cartItem,
                    Product product)
        {
            // Act
            var shoppingCartRepository = new Mock<IShoppingCartRepository>();
            shoppingCartRepository
                .Setup(r => r.AddItem(cartItemToAddDto))
                .ReturnsAsync(cartItem);

            var productRepository = new Mock<IProductRepository>();
            productRepository
                .Setup(r => r.GetProductById(cartItemToAddDto.ProductId))
                .ReturnsAsync(product);

            var controller = new ShoppingCartController(shoppingCartRepository.Object, productRepository.Object);

            var response = await controller.PostItem(cartItemToAddDto);

            // Assert
            var result = cartItem.ConvertToDto(product);

            response.Value.Id.Should().Be(result.Id);
            response.Value.ProductId.Should().Be(result.ProductId);
            response.Value.CartId.Should().Be(result.CartId);
            response.Value.ProductName.Should().Be(result.ProductName);
            response.Value.ProductDescription.Should().Be(result.ProductDescription);
            response.Value.ProductImageURL.Should().Be(result.ProductImageURL);
            response.Value.Price.Should().Be(result.Price);
            response.Value.TotalPrice.Should().Be(result.TotalPrice);
            response.Value.Qty.Should().Be(result.Qty);
        }

    }
}
