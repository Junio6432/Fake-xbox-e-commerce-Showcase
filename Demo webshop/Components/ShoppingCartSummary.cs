using Demo_webshop.Models.Services;
using Demo_webshop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo_webshop.Components
{
    public class ShoppingCartSummary: ViewComponent
    {

        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartSummary(IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var items = await _shoppingCart.GetShoppingCartItemsAsync();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart,
                await _shoppingCart.GetShoppingCartTotalAsync(), await _shoppingCart.GetShoppingCartTotalProductsAsync());

            return View(shoppingCartViewModel);

        }




    }
}
