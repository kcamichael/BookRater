using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookRater.Models.BookModels;

namespace BookRater.Services.BookServices
{
    public class BookService : IBookService
    {
        public Task<bool> AddBook(BookCreate model)
        {
            throw new NotImplementedException();
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