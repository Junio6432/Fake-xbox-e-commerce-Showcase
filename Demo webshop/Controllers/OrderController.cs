using Demo_webshop.Models;
using Demo_webshop.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo_webshop.Controllers
{
    [Authorize]
    public class OrderController: Controller
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCart _shoppingCart;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderRepository orderRepository, IShoppingCart shoppingCart, ILogger<OrderController> logger)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult CheckOutAsync()
        {

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> CheckOutAsync(Order order)
        {

            var items = await _shoppingCart.GetShoppingCartItemsAsync();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {

                ModelState.AddModelError("", "Your cart is empty, add some products first");

            }

            if (ModelState.IsValid)
            {

                await _orderRepository.CreateOrderAsync(order);
                await _shoppingCart.ClearCartAsync();
                _logger.Log(LogLevel.Information, $"Order{order.OrderId} created");
                return RedirectToAction("CheckoutComplete");

            }
            return View(order);

        }

        public IActionResult CheckoutCompleteAsync()
        {

            ViewBag.CheckoutCompleteMessage = "Thanks for your" +
                " order. We hope you enjoy your game";

            return View();

        }

    }
}
