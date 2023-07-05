using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookRater.Models.ReviewModels;

namespace BookRater.Services.ReviewServices
{
    public interface IReviewService
    {
        public Task<bool> AddReview(ReviewCreate model);
        public Task<bool> UpdateReview(ReviewEdit model);
        public Task<bool> DeleteReview(int id);
        public  Task<List<ReviewListItem>> GetReviews();
    }
}