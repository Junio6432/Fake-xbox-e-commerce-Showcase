namespace Demo_webshop.Models
{
    public class ShoppingCartItem
    {

        public int ShoppingCartItemId { get; set; }
        public Product product { get; set; } = default!;
        public int Amount { get; set; }
        public string? ShoppingCartId { get; set; }

    }
}
