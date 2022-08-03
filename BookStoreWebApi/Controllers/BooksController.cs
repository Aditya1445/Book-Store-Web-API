using BookStoreWebApi.DTO;
using BookStoreWebApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var _bookList = await _bookService.GetAllBookAsync();
            return Ok(_bookList);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            var _book = await _bookService.GetBookByIdAsync(id);
            if(_book == null)
            {
                return NotFound();
            }
            return Ok(_book);
        }
        [HttpPost("")]
        public async Task<IActionResult> AddNewBook([FromBody] BookModelDTO book)
        {
            var id = await _bookService.AddBookAsync(book);
            return CreatedAtAction(nameof(GetBookById), new {id=id, Controller="books"}, book);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromRoute] int id, [FromBody] BookModelDTO _book)
        {
             
            await _bookService.UpdateBookAsync(id, _book);                                      
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookById([FromRoute] int id)
        {
            await _bookService.DeleteBookAsync(id);
            return Ok();
        }
    }
}
