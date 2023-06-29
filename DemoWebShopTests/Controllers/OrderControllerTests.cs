using Demo_webshop.Controllers;
using Demo_webshop.Models;
using Demo_webshop.Models.Services;
using DemoWebShopTests.Mock;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace DemoWebShopTests.Controllers
{
    public class OrderControllerTests
    {

        Mock<IOrderRepository> _mockOrderRepository;
        Mock<IShoppingCart> _mockShoppingCartRepository;
        CustomLogger<OrderController> _logger;
        OrderController _orderController;

        public OrderControllerTests()
        {

            _mockOrderRepository = RepositoryMock.GetOrderRepository();
            _mockShoppingCartRepository = RepositoryMock.GetShoppingCartRepository();
            _logger = new CustomLogger<OrderController>();

            _orderController = new OrderController(_mockOrderRepository.Object,
                _mockShoppingCartRepository.Object, _logger);

        }

        [Fact]
        public async Task CheckOut_OrderCreated_RedirectedToCheckoutComplete()
        {

            //Arrange
            var order = new Order
            {
                OrderId = 1,
                OrderTotal = 100.00,
                ZipCode = "10100"
            };

            // Act
            var result = await _orderController.CheckOutAsync(order);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("CheckoutComplete", redirectToActionResult.ActionName);

        }
    }
}
