using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRater.Models.AuthorModels
{
    public class AuthorListItemVM
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
        
        public string FullName { get { return $"{FirstName} {LastName}"; } }
    }
}