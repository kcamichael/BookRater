using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookRater.API.Conttrollers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _bookService.GetDetail());
        }

        [HttpPost]
        public async Task<IActionResult> Post(BookCreate model)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            if (await _bookService.AddBook(model))
                return Ok("Book Added");
            else
                return StatusCode(500, "Internal Server Error.");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, BookEdit model)
        {
            if (id != model.Id)
                return BadRequest("Invalid Id");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (await _bookService.UpdateBook(model))
                return Ok("Book Updated!");
            else
                return StatusCode(500, "Internal Server Error.");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Id");

            if (await _bookService.DeleteBook(id))
                return Ok("Book Deleted!");
            else
                return StatusCode(500, "Internal Server Error.");
        }
    }
}