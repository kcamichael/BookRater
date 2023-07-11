using System.ComponentModel.DataAnnotations;

namespace BookRater.Models.GenreModels
{
    public class GenreCreate
    {
        [Required]
        public string GenreName { get; set; } = null!;
    }
}