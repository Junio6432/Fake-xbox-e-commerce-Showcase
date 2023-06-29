using Demo_webshop.Models.Services;
using Demo_webshop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.IO.Pipelines;
using System.Net;

namespace Demo_webshop.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : Controller
    {

        private readonly IProductRepository _productRepository;

        public SearchController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("{game}")]
        public async Task<IActionResult> GetByName(string game)
        {

            var product = await _productRepository.SearchProductsAsync(game);

            if (product == null)
            {

                return NotFound();

            }
            return PartialView("_SearchedProducts", product);

        }


    }
}
