using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BookRater.Data.Entities
{
    public class UserEntity : IdentityUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
    }
}