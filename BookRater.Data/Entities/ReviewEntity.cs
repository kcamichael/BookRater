using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookRater.Data.Entities
{
    public class ReviewEntity
    {
        [Required]
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}