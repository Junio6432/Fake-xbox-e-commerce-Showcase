using Demo_webshop.Models.Services;
using Demo_webshop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo_webshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> IndexAsync()
        {
            await _productRepository.GetAllProductsAsync();
            var homeViewModel = new HomeViewModel( _productRepository.AllProducts);
            return View(homeViewModel);
        }

        public async Task<PartialViewResult> IndexPartialAsync()
        {

            await _productRepository.GetAllProductsAsync();
            var homeViewModel = new HomeViewModel(_productRepository.AllProducts);

            return PartialView("_Index", homeViewModel);

        }

    }
}