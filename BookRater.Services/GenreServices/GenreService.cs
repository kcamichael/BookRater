using AutoMapper;
using BookRater.Data.BookRaterContext;
using BookRater.Data.Entities;
using BookRater.Models.GenreModels;

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
    }
}