using BookRater.Models.GenreModels;
using BookRater.Services.GenreServices;
using Microsoft.AspNetCore.Mvc;

namespace BookRater.API.Conttrollers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Genrecontroller : ControllerBase
    {
        private readonly IGenreService _gService;

        public Genrecontroller(IGenreService gService)
        {
            _gService = gService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(GenreCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _gService.CreateGenre(model))
            {
                return Ok("Success");
            }
            else
                return StatusCode(500, "Internal Server Error.");
        }
    }
}