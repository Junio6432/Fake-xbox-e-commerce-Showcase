using Demo_webshop.Components;
using Demo_webshop.Models.Services;
using Demo_webshop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.Text.Encodings.Web;

namespace Demo_webshop.Controllers
{
    public class ShoppingCartController: Controller
    {

        private readonly IProductRepository _productRepository;

        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartController(IProductRepository productRepository, IShoppingCart shoppingCart)
        {
            _productRepository = productRepository;
            _shoppingCart = shoppingCart;
        }

        public async Task<ViewResult> IndexAsync()
        {

            var items =  await _shoppingCart.GetShoppingCartItemsAsync();
            _shoppingCart.ShoppingCartItems = items.ToList();

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart,
                await _shoppingCart.GetShoppingCartTotalAsync(), await _shoppingCart.GetShoppingCartTotalProductsAsync());

            return View(shoppingCartViewModel);

        }

        public async Task<PartialViewResult> ShoppingCartPartialAsync()
        {

            var items = await _shoppingCart.GetShoppingCartItemsAsync();
            _shoppingCart.ShoppingCartItems = items.ToList();

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart,
                await _shoppingCart.GetShoppingCartTotalAsync(), await _shoppingCart.GetShoppingCartTotalProductsAsync());

            return PartialView("_ShoppingCart", shoppingCartViewModel);

        }

        [HttpGet]
        public async Task<IActionResult> AddToShoppingCartAsync(int productId)
        {

            await _productRepository.GetAllProductsAsync();

            var selectedProduct = _productRepository.AllProducts.FirstOrDefault(p => p.ProductId == productId);

            if (selectedProduct == null)
            {

                return NotFound();
                
            }
            else
            {
                await _shoppingCart.AddToCartAsync(selectedProduct);

                return Json(new { message = "The product was added" });
            }
            

        }

        
        public async Task<IActionResult> GetItemsQuantityAsync()
        {

            var items = await _shoppingCart.GetShoppingCartItemsAsync();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart,
                await _shoppingCart.GetShoppingCartTotalAsync(), await _shoppingCart.GetShoppingCartTotalProductsAsync());

            return PartialView("_Default", shoppingCartViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> RemoveShoppingCartAsync(int productId)
        {

            await _productRepository.GetAllProductsAsync();

            var selectedProduct = _productRepository.AllProducts.FirstOrDefault(p => p.ProductId == productId);

            if (selectedProduct != null)
            {

                await _shoppingCart.RemoveFromCartAsync(selectedProduct);

            }
            else
            {
                return NotFound();
            }

            return Json(new { message = "The product was removed" });

        }

        public async Task<IActionResult> ClearShoppingCartAsync()
        {

            await _shoppingCart.ClearCartAsync();

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart,
                await _shoppingCart.GetShoppingCartTotalAsync(), await _shoppingCart.GetShoppingCartTotalProductsAsync());

            return Json(new { message = "The product was added" });

        }
    }
}
