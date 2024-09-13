using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_free.Helpers;
using WebAPI_free.Models;
using WebAPI_free.Repositories;

namespace WebAPI_free.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IbookRepostory _bookres;

        public ProductsController(IbookRepostory bookRepostory)
        {
            _bookres = bookRepostory;
        }
        [HttpGet]
        [Authorize(Roles = AppRole.Customer)]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                return Ok( await _bookres.GetAllBooksAsync());
            }
            catch
            {
                return BadRequest("loi");
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _bookres.GetBookAsync(id);
            return (book == null) ? NotFound("loi") : Ok(book);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddNewBook(BookModel model)
        {
            try
            {
                  var newbookid = await _bookres.AddBookAsync(model);
                var book = await _bookres.GetBookAsync(newbookid);
                return (book == null) ? NotFound("loi") : Ok(book);
            }
            catch
            {
                return BadRequest("loi");
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public  async Task<IActionResult> UpdateBook(int id, BookModel model)
        {
            if(id != model.Id) return NotFound("khong co id nhu nay");
            await _bookres.UpdateBookAsync(id, model);
            return Ok("da sua thanh cong");
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if(id <=0)
            {
                return NotFound($"khong co id: {id} ");
            }
            else
            {
                await _bookres.DeleteBookAsync(id);
                return Ok("da xoa thanh cong");
            }
           
        }
    }
}
