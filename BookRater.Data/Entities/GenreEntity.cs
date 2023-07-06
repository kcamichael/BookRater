using System.ComponentModel.DataAnnotations;

namespace BookRater.Data.Entities
{
    public class GenreEntity
    {
        [Required]
        public int Id { get; set; }
        public string GenreName { get; set; }
    }
}