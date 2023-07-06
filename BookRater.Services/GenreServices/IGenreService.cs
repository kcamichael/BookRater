using BookRater.Models.GenreModels;

namespace BookRater.Services.GenreServices
{
    public interface IGenreService
    {
        Task<bool> CreateGenre(GenreCreate model);
    }
}