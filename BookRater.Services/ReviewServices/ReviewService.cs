using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookRater.Data.BookRaterContext;
using BookRater.Data.Entities;
using BookRater.Models.ReviewModels;
using Microsoft.EntityFrameworkCore;

namespace BookRater.Services.ReviewServices
{
    public class ReviewService : IReviewService
    {
        private readonly BookRaterDBContext _context;
        private readonly IMapper _mapper;
        public ReviewService(BookRaterDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddReview(ReviewCreate model)
        {
            var review = new ReviewEntity
            {
               Comment = model.Comment,
              
            };
            await _context.Reviews.AddAsync(review);
            return await _context.SaveChangesAsync() > 0;
        } 

        public async Task<bool> DeleteReview(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if(review is null)
            return false;
            _context.Reviews.Remove(review);
            return await _context.SaveChangesAsync() >0;
        }

        public async Task<ReviewDetail> GetReview(int id)
        {
            var review =await _context.Reviews.Include(r => r.BookRatings).FirstOrDefaultAsync(x => x.Id == id);
            if(review is null)
                return new ReviewDetail();
            
            return _mapper.Map<ReviewDetail>(review);
        }

        public async Task<List<ReviewListItem>> GetReviews()
        {
            var review = await _context.Reviews.Include(r => r.BookRatings).ToListAsync();
            var ReviewListItem = _mapper.Map<List<ReviewListItem>>(review);
            return ReviewListItem;
        }

        public async Task<bool> UpdateReview(ReviewEdit model)
        {
           var review = await _context.Reviews.SingleOrDefaultAsync (x => x.Id == model.Id);
           if(review is not null)
           {
             review.Comment = model.Comment;
             await _context.SaveChangesAsync();
             return true;
           }
           return false;
        }
    }
} 