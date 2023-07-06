using BookRater.Models.GenreModels;
using BookRater.Services.GenreServices;
using Microsoft.AspNetCore.Mvc;

namespace BookRater.API.Conttrollers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Genrecontroller : ControllerBase
    {
        private readonly IGenreService _genreService;

        public Genrecontroller(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(GenreCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _genreService.CreateGenre(model))
            {
                return Ok("Success");
            }
            else
                return StatusCode(500, "Internal Server Error.");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _genreService.DeleteGenre(id))
                return Ok("Genre Deleted!");
            else
                return StatusCode(500, "Internal Sever Error");
        }
    }
}