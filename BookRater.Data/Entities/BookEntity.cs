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

        // [Key]
        // public int Id { get; set; }

        // [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        // public string Title { get; set; } = null!;

        // public int GameSystemId { get; set; }
        // [ForeignKey(nameof(GameSystemId))]
        // public virtual GameSystemEntity GameSystem { get; set; }

        // public int GenreId { get; set; }
        // [ForeignKey(nameof(GenreId))]
        // public virtual GenreEntity Genre { get; set; }

        // public string? UserId { get; set; }
        // [ForeignKey(nameof(UserId))]
        // public virtual UserEntity User { get; set; }
