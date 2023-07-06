using System.ComponentModel.DataAnnotations;

namespace BookRater.Models.UserModels
{
    public class UserEntityVM : Login
    {
        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;
    }
}