using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BookRater.Data.Entities;

namespace BookRater.Models.ReviewModels
{
    public class ReviewEdit
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(350)]
        public string Comment { get; set; }
        [Required]
        public int Rating { get; set; }
        public List<ReviewEntity>Reviews { get; set; }
    }
}