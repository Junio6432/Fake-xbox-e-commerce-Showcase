using Demo_webshop.Controllers;
using Demo_webshop.Models.Services;
using Demo_webshop.ViewModels;
using DemoWebShopTests.Mock;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Security.Claims;

namespace DemoWebShopTests.Controllers
{
    public class ShoppingCartControllerTests
    {

        Mock<IProductRepository> _productRepository;
        Mock<IShoppingCart> _mockShoppingCartRepository;
        ShoppingCartController _shoppingCartController;

        public ShoppingCartControllerTests()
        {

            _productRepository = RepositoryMock.GetProductRepository();
            _mockShoppingCartRepository = RepositoryMock.GetShoppingCartRepository();

            _shoppingCartController = new ShoppingCartController(_productRepository.Object,
                _mockShoppingCartRepository.Object);

        }

        [Fact]
        public async Task GetItemsQuantityAsync_ReturnAllShoppingCartProducts()
        {

            //arrange


            //act

            var result = await _shoppingCartController.IndexAsync();

            //assert

            var viewResult = Assert.IsType<ViewResult>(result);
            var ShoppingCartViewModel = Assert.IsAssignableFrom<ShoppingCartViewModel>
                (viewResult.ViewData.Model);
            Assert.Equal(6, ShoppingCartViewModel.ShoppingCartTotalProducts);

        }

        [Fact]
        public async Task ShoppingCartPartialAsync_PartialViewIsReturned()
        {

            //arrange


            //act

            var result = await _shoppingCartController.ShoppingCartPartialAsync();

            //assert

            Assert.IsType<PartialViewResult>(result);

        }

        [Fact]
        public async Task DeleteProductAsync_InValidProductId_ReturnsNotFound()
        {

            //arrange


            //act
            var result = await _shoppingCartController.RemoveShoppingCartAsync(8);

            //assert

            Assert.IsType<NotFoundResult>(result);

        }

    }
}
