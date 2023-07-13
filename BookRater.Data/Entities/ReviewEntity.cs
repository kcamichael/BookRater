using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookRater.Data.Entities
{
    public class ReviewEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Comment { get; set; }
        public List<BookRating> BookRatings { get; set; }
    }
}