namespace ShopOnline.Api.IntegrationTests.Tests
{
    public class ProductControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private HttpClient _httpClient;

        public ProductControllerTest(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async void GetItems_WithoutQuerryParameters_ReturnsOkResult()
        {
            //act
            var response = await _httpClient.GetAsync("api/Product");

            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public async void GetItem_WithProductId_ReturnsOkResult(int id)
        {
            //act
            var response = await _httpClient.GetAsync($"api/Product/{id}");

            // assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Theory]
        [InlineData(1050)]
        [InlineData(2000)]
        public async void GetItem_WithProductId_ReturnsBadRequest(int id)
        {
            //act
            var response = await _httpClient.GetAsync($"api/Product/{id}");

            // assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }
    }
}