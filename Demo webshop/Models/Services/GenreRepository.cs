using Microsoft.EntityFrameworkCore;

namespace Demo_webshop.Models.Services
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DemoWebShopDBContext _webDBContext;

        public GenreRepository(DemoWebShopDBContext webShopDBContext)
        {
            _webDBContext = webShopDBContext;
        }

        private IEnumerable<Genre> _allGenres = null!;

        public async Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            _allGenres = await _webDBContext.Genres.OrderBy(p => p.GenreName).ToListAsync();
            SetGenres(_allGenres);
            return _allGenres;
        }

        private void SetGenres(IEnumerable<Genre> genres)
        {
            _allGenres = genres;
        }

        public IEnumerable<Genre> AllGenres => _allGenres;
    }
}
