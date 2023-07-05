using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookRater.Models.AuthorModels
{
    public class AuthorEditVM
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Text cannot exceed 50 characters.")]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(50, ErrorMessage = "Text cannot exceed 50 characters.")]
        public string LastName { get; set; } = string.Empty;
    }
}