using Microsoft.AspNetCore.Mvc;

namespace Demo_webshop.Controllers
{
    public class ContactController: Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}
