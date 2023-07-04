using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRater.Models.ReviewModels
{
    public class ReviewDetail
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public List<ReviewListItem>Reviews { get; set; }
    }
}