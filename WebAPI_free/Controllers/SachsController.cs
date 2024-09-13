using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_free.Models;
using WebAPI_free.Repositories;

namespace WebAPI_free.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SachsController : ControllerBase
    {
        private readonly IbookRepostory _bookres;

        public SachsController(IbookRepostory bookRepostory)
        {
            _bookres = bookRepostory;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var books = await _bookres.GetAllBooksAsync();
                if (books == null || !books.Any())
                {
                    return NotFound("No books found.");
                }
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            try
            {
                var book = await _bookres.GetBookAsync(id);
                if (book == null)
                {
                    return NotFound($"Book with ID {id} not found.");
                }
                return Ok(book);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Invalid book data.");
                }

                var newbookid = await _bookres.AddBookAsync(model);
                var book = await _bookres.GetBookAsync(newbookid);

                if (book == null)
                {
                    return NotFound("Error adding book, please try again.");
                }

                return CreatedAtAction(nameof(GetBook), new { id = newbookid }, book); // Returns 201 status with book details
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error adding data: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, BookModel model)
        {
            try
            {
                if (id != model.Id)
                {
                    return BadRequest("ID mismatch.");
                }

                var existingBook = await _bookres.GetBookAsync(id);
                if (existingBook == null)
                {
                    return NotFound($"Book with ID {id} not found.");
                }

                await _bookres.UpdateBookAsync(id, model);
                return NoContent(); // Returns 204 status, indicating success without content
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating data: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                var book = await _bookres.GetBookAsync(id);
                if (book == null)
                {
                    return NotFound($"Book with ID {id} not found.");
                }

                await _bookres.DeleteBookAsync(id);
                return NoContent(); // Returns 204 status after successful deletion
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting data: {ex.Message}");
            }
        }
    }
}
