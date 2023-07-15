using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BookRater.Models.AuthorModels;
using BookRater.Models.GenreModels;
using BookRater.Models.ReviewModels;

namespace BookRater.Models.BookModels
{
    public class BookDetail
    {
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [MaxLength(500, ErrorMessage = "Title cannot exceed 500 characters.")]
        public string Summary { get; set; } = string.Empty;

        public AuthorListItemVM Author { get; set; }

        public ReviewListItem Review { get; set; }

        public GenreListItem Genre { get; set; }
    }
}