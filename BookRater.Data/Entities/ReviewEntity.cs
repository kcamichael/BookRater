using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRater.Data.Entities
{
    public class ReviewEntity
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}