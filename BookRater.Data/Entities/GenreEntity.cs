using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookRater.Data.Entities
{
    public class GenreEntity
    {
        [Required]
        public int Id { get; set; }
        public string GenreName { get; set; }
    }
}