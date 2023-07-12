using System.ComponentModel.DataAnnotations;

namespace BookRater.Data.Entities
{
    public class GenreEntity
    {
        public int Id { get; set; }
        [Required]
        public string GenreName { get; set; } = null!;
    }
}