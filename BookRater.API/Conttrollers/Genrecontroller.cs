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
                return BadRequest(ModelState);
            if (await _genreService.CreateGenre(model))
                return Ok("Success. Post");
            else
                return StatusCode(500, "Internal Server Error. HttpPost Else Statement");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _genreService.DeleteGenre(id))
                return Ok("Genre Deleted!");
            else
                return StatusCode(500, "Internal Sever Error. HttpDelete Else Statement");
        }

        [HttpPut]
        public async Task<IActionResult> Put(GenreEdit model, int id)
        {
            if (id != model.Id)
            {
                return BadRequest("Invalid Id");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _genreService.UpdateGenre(model))
            {
                return Ok("Genre Updated");
            }
            else
                return StatusCode(500, "Internal Server Error. HttpPut Else Statement");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _genreService.GetGenres());
        }
    }
}