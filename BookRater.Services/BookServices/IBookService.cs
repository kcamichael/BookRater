using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookRater.Models.BookModels;

namespace BookRater.Services.BookServices
{
    public interface IBookService
    {
        //    Task<bool> represents the 'return type'
        //    After all is said and done return true/false
        Task<bool> AddBook(BookCreate model);
        Task<bool> UpdateBook(BookEdit model);
        Task<bool> DeleteBook(int id);
        public Task<BookDetail> GetDetail(int id);
        public Task<List<BookListItem>> GetBooks();
        public Task<List<BookListItem>> GetBookByGenre();
        public Task<List<BookListItem>> GetBookByAuthor();
    }
}
