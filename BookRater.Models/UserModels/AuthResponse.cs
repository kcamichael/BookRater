using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRater.Models.UserModels
{
    public class AuthResponse
    {
        public string UserName { get; set; } = null!;

        public string Token { get; set; } = null!;
    }
}