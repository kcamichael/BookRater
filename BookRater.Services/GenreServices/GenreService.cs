using BookRater.Data.BookRaterContext;
using BookRater.Data.Entities;
using BookRater.Models.GenreModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BookRater.Services.GenreServices
{
    public class GenreService : IGenreService
    {
        private readonly BookRaterDBContext _context;

        private readonly IMapper _mapper;

        public GenreService(BookRaterDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateGenre(GenreCreate model)
        {
            var entity = _mapper.Map<GenreEntity>(model);

            await _context.Genre.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteGenre(int id)
        {
            var genre = await _context.Genre.FirstOrDefaultAsync(g => g.Id == id);
            if (genre is null)
                return false;
            _context.Genre.Remove(genre);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateGenre(GenreEdit model)
        {
            var genre = await _context.Genre.Include(genre => genre.GenreName).SingleOrDefaultAsync(g => g.Id == model.Id);
            if (genre is null)
                return false;

            genre.Id = model.Id;
            genre.GenreName = model.GenreName;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<GenreListItem>> GetGenres()
        {
            var genres = await _context.Genre.ToListAsync();

            var genresListItems = _mapper.Map<List<GenreListItem>>(genres);

            return genresListItems;
        }
    }
}