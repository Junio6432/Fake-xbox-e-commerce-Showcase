using Demo_webshop.Controllers;
using Demo_webshop.Models;
using Demo_webshop.Models.Services;
using Demo_webshop.ViewModels;
using DemoWebShopTests.Mock;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Security.Claims;

namespace DemoWebShopTests.Controllers
{
    public class ProductControllerTests
    {

        Mock<IProductRepository> _mockProductRepository;
        Mock<IGenreRepository> _mockGenreRepository;
        ProductsController _productController;

        public ProductControllerTests()
        {

            _mockProductRepository = RepositoryMock.GetProductRepository();
            _mockGenreRepository = RepositoryMock.GetGenreRepository();

            _productController = new ProductsController(_mockProductRepository.Object,
                _mockGenreRepository.Object);

        }

        [Fact]
        public async Task DetailsAsync_ValidProductId_ReturnsSelectedProduct()
        {

            //arrange


            //act
            var result = await _productController.DetailsAsync(6);

            //assert

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Product>(viewResult.Model);


            Assert.Equal(6, model.ProductId);

        }

        [Fact]
        public async Task DetailsAsync_InvalidProductId_Returns404()
        {

            //arrange


            //act
            var result = await _productController.DetailsAsync(70);

            //assert

             Assert.IsType<NotFoundResult>(result);

        }

        [Fact]
        public async Task DeleteProductAsync_InValidProductId_ReturnsNotFound()
        {

            //arrange

            var user = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, "username"),
                new Claim(ClaimTypes.Role, "manager")
            }));

            var httpContext = new DefaultHttpContext
            {
                User = user
            };

            _productController.ControllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };

            //act
            var result = await _productController.DeleteProductAsync(7);

            //assert

            Assert.IsType<NotFoundResult>(result);

        }

    }
}
