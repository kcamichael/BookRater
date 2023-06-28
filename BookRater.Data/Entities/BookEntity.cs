using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookRater.Data.Entities
{
    public class BookEntity
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(100, ErrorMessage = "Title cannot exceed 300 characters.")]
        public string Title { get; set; } = string.Empty;
        [MaxLength(500, ErrorMessage = "Title cannot exceed 300 characters.")]
        public string Summary { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public int UserId { get; set; }
        public int ReviewId { get; set; }
        public int GenreId { get; set; }
    }
}