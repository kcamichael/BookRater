using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookRater.Models.ReviewModels;
using BookRater.Services.ReviewServices;
using Microsoft.AspNetCore.Mvc;

namespace BookRater.API.Conttrollers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService) 
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _reviewService.GetReviews());
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var review = await _reviewService.GetReview(id);
            if(review is null)
                return NotFound();
            else
                return Ok(review);    
        }

        [HttpPost]
        public async Task<IActionResult> Post(ReviewCreate model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(await _reviewService.AddReview(model))
                return Ok("Review Created!");
            else
                return StatusCode(500, "Internal Server Error.");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete (int id)
        {
            if(await _reviewService.DeleteReview(id))
                return Ok("Review Deleted!");
            else
                return StatusCode(500, "Internal Server Error.");    
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(ReviewEdit model, int id)
        {
            if(id != model.Id)
            {
                return BadRequest("Invalid Id.");
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(await _reviewService.UpdateReview(model))
                return Ok("Review Updated!");
            else 
                return StatusCode(500, "Internal Server Error.");    
        }

    }

}