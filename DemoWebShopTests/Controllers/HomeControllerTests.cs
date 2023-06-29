using Demo_webshop.Controllers;
using Demo_webshop.Models.Services;
using Demo_webshop.ViewModels;
using DemoWebShopTests.Mock;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DemoWebShopTests.Controllers
{
    public class HomeControllerTests
    {

        Mock<IProductRepository> _mockProductRepository;
        HomeController _homeController;

        public HomeControllerTests()
        {

            _mockProductRepository = RepositoryMock.GetProductRepository();

            _homeController = new HomeController(_mockProductRepository.Object);

        }

        [Fact]
        public async Task IndexAsync_ReturnAllProducts()
        {

            //arrange


            //act

            var result = await _homeController.IndexAsync();

            //assert

            var viewResult = Assert.IsType<ViewResult>(result);
            var HomeViewModel = Assert.IsAssignableFrom<HomeViewModel>
                (viewResult.ViewData.Model);
            Assert.Equal(6, HomeViewModel.AllGames.Count());

        }

        [Fact]
        public async Task IndexPartialAsync_PartialViewIsReturned()
        {

            //arrange


            //act

            var result = await _homeController.IndexPartialAsync();

            //assert

            Assert.IsType<PartialViewResult>(result);

        }

    }
}
