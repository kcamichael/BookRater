using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRater.Models.ReviewModels
{
    public class ReviewCreate
    {
        [Required]
        [MaxLength(350)]
        public string Comment { get; set; }
       
    }
}