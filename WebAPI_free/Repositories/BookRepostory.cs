using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI_free.Data;
using WebAPI_free.Models;

namespace WebAPI_free.Repositories
{
    public class BookRepostory : IbookRepostory
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public BookRepostory(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddBookAsync(BookModel model)
        {
            var newbook = _mapper.Map<Book>(model);
            _context.Books.Add(newbook);
            await _context.SaveChangesAsync();
            return newbook.Id;
        }

        public async Task DeleteBookAsync(int id)
        {
            var deletebook = _context.Books.SingleOrDefault(d => d.Id == id);
            if(deletebook != null)
            {
                 _context.Books.Remove(deletebook);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            var book = await _context.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(book);
        }

        public async Task<BookModel> GetBookAsync(int id)
        {
            var bookid = await _context.Books.FindAsync(id);
            return _mapper.Map<BookModel>(bookid);
        }

        public async Task UpdateBookAsync(int id, BookModel model)
        {
            if(id == model.Id)
            {
                var updatebook = _mapper.Map<Book>(model);
                _context.Books.Update(updatebook);
                await _context.SaveChangesAsync();
            }
        }
    }
}
