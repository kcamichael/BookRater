using System.ComponentModel.DataAnnotations;

namespace BookRater.Models.GenreModels
{
    public class GenreEdit
    {
        [Required]
        public int Id { get; set; }
        public string GenreName { get; set; } = null!;
    }
}