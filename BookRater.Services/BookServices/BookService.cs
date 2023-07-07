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

        public async Task<BookDetail> GetDetail(int id)
        {
            var book = await _context.Book.Include(b => b.AuthorId).Include(b => b.GenreId).Include(b => b.ReviewId).SingleOrDefaultAsync(x => x.Id == id);
            if (book is null) return null!;

            return _mapper.Map<BookDetail>(book);
        }

        public async Task<List<BookListItem>> GetBooks()
        {
            return await _context.Book.Select(b => _mapper.Map<BookListItem>(p)).ToListAsync();
        }

        public async Task<List<BookListItem>> GetBookByGenre(int GenreId)
        {
            var book = await _context.Book.FindAsync(GenreId);
            return _mapper.Map<List<BookListItem>>(book);
        }

        public async Task<List<BookListItem>> GetBookByAuthor(int AuthorId)
        {
            var book = await _context.Book.FindAsync(AuthorId);
            return _mapper.Map<List<BookListItem>>(book);
        }
    }
}