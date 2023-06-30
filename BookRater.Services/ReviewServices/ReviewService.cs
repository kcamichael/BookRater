using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookRater.Data.BookRaterContext;

namespace BookRater.Services.ReviewServices
{
    public class ReviewService : IReviewService
    {
        private readonly BookRaterDBContext _context;
        private readonly IMapper _mapper;

        public ReviewService(BookRaterDBContext context, IMapper mapper)
        {
            
            
        }



    }
}