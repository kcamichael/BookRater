using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BookRater.Data.Entities
{
    public class UserEntity : IdentityUser
    {
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string LastName { get; set; } = string.Empty;

        public string FullName { get { return $"{FirstName} {LastName}"; } }

        public DateTime DateCreated { get; set; }
    }
}