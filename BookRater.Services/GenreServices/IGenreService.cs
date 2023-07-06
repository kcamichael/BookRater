using BookRater.Models.GenreModels;

namespace BookRater.Services.GenreServices
{
    public interface IGenreService
    {
        Task<bool> CreateGenre(GenreCreate model);
        Task<bool> DeleteGenre(int id);
        Task<bool> UpdateGenre(GenreEdit model);
    }
}