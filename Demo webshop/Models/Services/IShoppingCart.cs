namespace Demo_webshop.Models.Services
{
    public interface IShoppingCart
    {

        Task AddToCartAsync(Product product);
        Task RemoveFromCartAsync(Product product);
        Task<List<ShoppingCartItem>> GetShoppingCartItemsAsync();
        Task ClearCartAsync();
        Task<double> GetShoppingCartTotalAsync();
        Task<double> GetShoppingCartTotalProductsAsync();
        List<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}
