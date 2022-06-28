
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using ShopOnline.Api.Controllers;
using ShopOnline.Api.Data;
using ShopOnline.Api.Entities;
using ShopOnline.Api.Extensions;
using ShopOnline.Api.Repositories;
using ShopOnline.Api.Repositories.Contracts;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.IntegrationTests
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

        #region CreateParameters
        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { 
                new CartItemToAddDto
                {
                    CartId = 1,
                    ProductId = 1,
                    Qty = 1

                },
                new CartItem
                {
                    Id = 1,
                    CartId = 1,
                    ProductId = 1,
                    Qty = 1
                },
                new Product
                {
                    Id = 1,
                    Name = "Glossier - Beauty Kit",
                    Description = "A kit provided by Glossier, containing skin care, hair care and makeup products",
                    ImageURL = "/Images/Beauty/Beauty1.png",
                    Price = 100,
                    Qty = 100,
                    CategoryId = 1
                }  
            },
            new object[] {
                new CartItemToAddDto
                {
                    CartId = 2,
                    ProductId = 2,
                    Qty = 45
                },
                new CartItem
                {
                    Id = 2,
                    CartId = 2,
                    ProductId = 2,
                    Qty = 45
                },
                new Product
                {
                    Id = 2,
                    Name = "Curology - Skin Care Kit",
                    Description = "A kit provided by Curology, containing skin care products",
                    ImageURL = "/Images/Beauty/Beauty2.png",
                    Price = 50,
                    Qty = 45,
                    CategoryId = 1
                }
            },
            new object[] {
                new CartItemToAddDto
                {
                    CartId = 1,
                    ProductId = 5,
                    Qty = 30
                },
                new CartItem
                {
                    Id = 3,
                    CartId = 1,
                    ProductId = 5,
                    Qty = 30
                },
                new Product
                {
                    Id = 5,
                    Name = "Skin Care Kit",
                    Description = "Skin Care Kit, containing skin care and hair care products",
                    ImageURL = "/Images/Beauty/Beauty5.png",
                    Price = 30,
                    Qty = 85,
                    CategoryId = 1
                }
            }

        };
        #endregion

        [Theory]
        [MemberData(nameof(Data))]
        public async void PostItem_WithCartItemToAddDto_ReturnsCartItemDto(
                    CartItemToAddDto cartItemToAddDto,
                    CartItem cartItem,
                    Product product)
        {
            //arrange

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

            response.Value.ProductName.Should().Be(result.ProductName);
            response.Value.Id.Should().Be(result.Id);
            response.Value.Qty.Should().Be(result.Qty);
            response.Value.ProductImageURL.Should().Be(result.ProductImageURL);

        }

    }
}
