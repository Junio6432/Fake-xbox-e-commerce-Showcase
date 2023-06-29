using Demo_webshop.Models;

namespace Demo_webshop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> AllGames { get; }

        public HomeViewModel(IEnumerable<Product> allGames)
        {

            AllGames = allGames;

        }

    }
}
