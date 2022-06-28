using ShopOnline.Api.Entities;
using ShopOnline.Api.IntegrationTests.DatabaseTestModels;
using ShopOnline.Models.Dtos;
using System.Collections;


namespace ShopOnline.Api.IntegrationTests.ClassData.ShoppingCartController
{
    public class PostItemData : IEnumerable<object[]>
    {
        TestProductsData testProductData = new TestProductsData();
        TestCartItemData testCartItemData = new TestCartItemData();
        public IEnumerator<object[]> GetEnumerator()
        {
            foreach (var item in testCartItemData.CartItems)
            {
                yield return new object[] {
                    new CartItemToAddDto
                    {
                        CartId = item.CartId,
                        ProductId = item.ProductId,
                        Qty = item.Qty
                    },
                    item,
                    testProductData.Products.Find(p => p.Id == item.ProductId)
                };
            }

        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
