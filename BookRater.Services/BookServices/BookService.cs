using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookRater.Data.BookRaterContext;
using BookRater.Data.Entities;
using BookRater.Models.BookModels;

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

        public Task<bool> DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BookDetail> GetDetail(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BookListItem>> GetGenreLists()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateBook(BookEdit model)
        {
            throw new NotImplementedException();
        }
    }
}