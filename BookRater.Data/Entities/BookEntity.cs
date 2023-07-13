using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookRater.Data.Entities
{
    public class BookEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Title cannot exceed 300 characters.")]
        public string Title { get; set; } = string.Empty;

        [MaxLength(500, ErrorMessage = "Title cannot exceed 300 characters.")]
        public string Summary { get; set; } = string.Empty;

        [Required]
        public int AuthorId { get; set; }
        public AuthorEntity Author { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ReviewId { get; set; }
        public ReviewEntity Review { get; set; }


        [Required]
        public int GenreId { get; set; }
        public GenreEntity Genre { get; set; }

    }
}