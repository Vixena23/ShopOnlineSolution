using ShopOnline.Api.Entities;

namespace ShopOnline.Api.IntegrationTests.DatabaseTestModels
{
    public class TestCartItemData
    {
        public List<CartItem> CartItems = new List<CartItem>
        {
            new CartItem
                {
                    Id = 1,
                    CartId = 1,
                    ProductId = 1,
                    Qty = 1
                },
            new CartItem
                {
                    Id=2,
                    CartId = 2,
                    ProductId = 2,
                    Qty = 45
                },
            new CartItem{
                    Id=3,
                    CartId = 1,
                    ProductId = 5,
                    Qty = 30
                },
        };
    }
}
