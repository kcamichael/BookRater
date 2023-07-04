using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookRater.Models.BookModels;

namespace BookRater.Services.BookServices
{
    public interface IBookService
    {
        Task<bool> AddBook(BookCreate model);
        Task<bool> DeleteBook(int id);
        Task<bool> UpdateBook(BookEdit model);
        public Task<BookDetail> GetDetail(int id);
        public Task<List<BookListItem>> GetGenreLists();
    }
}

