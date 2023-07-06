using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookRater.Data.Entities
{
    public class BookRating
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Rating { get; set; }
        public int ReviewEntityId { get; set; }
        [ForeignKey(nameof(ReviewEntityId))]
        public virtual ReviewEntity ReviewEntity { get; set; }
    }
}