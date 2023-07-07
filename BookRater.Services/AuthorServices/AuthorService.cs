using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookRater.Data.BookRaterContext;
using BookRater.Data.Entities;
using BookRater.Models.AuthorModels;
using Microsoft.EntityFrameworkCore;

namespace BookRater.Services.AuthorServices
{
    public class AuthorService : IAuthorService
    {
        private readonly BookRaterDBContext _context;
        private readonly IMapper _mapper;

        public AuthorService(BookRaterDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateAuthor(AuthorCreateVM model)
        {
            var entity = _mapper.Map<AuthorEntity>(model);

            await _context.Authors.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if(author is null) return false;

            _context.Authors.Remove(author);
            
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<AuthorDetailVM> GetAuthor(int id)
        {
            var author = await _context.Authors.SingleOrDefaultAsync(x => x.Id == id);

            if(author is null) return new AuthorDetailVM{};

            return _mapper.Map<AuthorDetailVM>(author);
        }

        public async Task<List<AuthorListItemVM>> GetAuthors()
        {
            var authors = await _context.Authors.ToListAsync();

            var authorsListItems = _mapper.Map<List<AuthorListItemVM>>(authors);

            return authorsListItems;
        }

        public async Task<bool> UpdateAuthor(AuthorEditVM model)
        {
            var author = await _context.Authors.SingleOrDefaultAsync(x => x.Id == model.Id);

            if (author is null) return false;

            author.FirstName = model.FirstName;
            author.LastName = model.LastName;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}