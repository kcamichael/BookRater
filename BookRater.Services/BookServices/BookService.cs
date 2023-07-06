using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookRater.Data.BookRaterContext;
using BookRater.Data.Entities;
using BookRater.Models.BookModels;
using Microsoft.EntityFrameworkCore;

namespace BookRater.Services.BookServices
{
    public class BookService : IBookService
    {
        private readonly BookRaterDBContext _context;
        private readonly IMapper _mapper;

        public BookService(BookRaterDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddBook(BookCreate model)
        {
            var entity = _mapper.Map<BookEntity>(model);

            if (entity is not null)
            {
                await _context.Book.AddAsync(entity);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<bool> DeleteBook(int id)
        {
            var book = await _context.Book.FirstOrDefaultAsync(b => b.Id == id);
            if (book is null)
                return false;
            _context.Book.Remove(book);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<BookDetail> GetDetail(int id)
        {
            var book = await _context.Book.Include(b => b.Title).Include(b => b.AuthorId).Include(b => b.GenreId).Include(b => b.Summary).Include(b => b.ReviewId).SingleOrDefaultAsync(x => x.Id == id);     //does this mean if any one of these returns null it wont return the values? Or will it return what it has?
            if (book is null) return null!;

            return _mapper.Map<BookDetail>(book);
        }

        public async Task<List<BookListItem>> GetGenreLists()
        {
            var book = await _context.Book.ToListAsync();
            return _mapper.Map<List<BookListItem>>(book);
        }

        public async Task<bool> UpdateBook(BookEdit model)
        {
            var book = await _context.Book.AsNoTracking().SingleOrDefaultAsync(x => x.Id == model.Id);
            if (book is null) return false;

            var conversion = _mapper.Map<BookEdit, BookEntity>(model);

            if (conversion is not null)
            {
                _context.Book.Update(conversion);

                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}