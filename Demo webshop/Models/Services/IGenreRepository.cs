namespace Demo_webshop.Models.Services
{
    public interface IGenreRepository
    {

        IEnumerable<Genre> AllGenres { get; }
        Task<IEnumerable<Genre>> GetAllGenresAsync();

    }
}
