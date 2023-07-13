using BookRater.Models.AuthorModels;
using BookRater.Services.AuthorService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookRater.API.Conttrollers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authService;

        public AuthorController(IAuthorService authService)
        {
            _authService = authService;
        }

        [Authorize(Roles = "User, Administrator")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _authService.GetAuthors());
        }

        [Authorize(Roles = "User, Administrator")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _authService.GetAuthor(id));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> Post(AuthorCreateVM model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(await _authService.CreateAuthor(model))
            {
                return Ok("Success");
            }
            else
            return StatusCode(500, "Internal Server Error");
        }
        
        [Authorize(Roles = "Administrator")]
        [HttpPut]
        public async Task<IActionResult> Put(AuthorEditVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _authService.UpdateAuthor(model))
            {
                return Ok("Success");
            }
            else
            return StatusCode(500, "Internal Server Error");
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id<=0)
            {
                return BadRequest("Invalid Id");
            }

            if (await _authService.DeleteAuthor(id))
            {
                return Ok("Success");
            }
            else
            return StatusCode(500, "Internal Server Error");
        }
    }
}