using Demo_webshop.Models.Services;

namespace Demo_webshop.ViewModels
{
    public class ShoppingCartViewModel
    {

        public IShoppingCart ShoppingCart { get; }
        public double ShoppingCartTotal { get; }
        public double ShoppingCartTotalProducts { get; }

        public ShoppingCartViewModel(IShoppingCart shoppingCart, double shoppingCartTotal, double shoppingCartTotalProducts)
        {

            ShoppingCart = shoppingCart;
            ShoppingCartTotal = shoppingCartTotal;
            ShoppingCartTotalProducts = shoppingCartTotalProducts;
        }

    }
}
