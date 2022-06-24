using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;

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

    }
}
