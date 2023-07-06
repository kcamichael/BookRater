using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookRater.Models.AuthorModels;

namespace BookRater.Services.AuthorServices
{
    public interface IAuthorServices
    {
        Task<bool> CreateAuthor(AuthorCreateVM model);

        Task<bool> UpdateAuthor(AuthorEditVM model);

        Task<bool> DeleteAuthor(int id);

        Task<AuthorDetailVM> GetAuthor(int id);
        
        Task<List<AuthorListItemVM>> GetAuthors();
    }
}