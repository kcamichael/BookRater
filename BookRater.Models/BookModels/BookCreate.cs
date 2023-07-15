using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookRater.Models.BookModels
{
    public class BookCreate
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [MaxLength(500, ErrorMessage = "Title cannot exceed 500 characters.")]
        public string Summary { get; set; } = string.Empty;

        [Required]
        public int AuthorId { get; set; }

        [Required]
        public int GenreId { get; set; }
    }
}