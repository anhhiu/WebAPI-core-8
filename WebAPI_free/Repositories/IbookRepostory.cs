using WebAPI_free.Data;
using WebAPI_free.Models;

namespace WebAPI_free.Repositories
{
    public interface IbookRepostory
    {
        public Task<List<BookModel>> GetAllBooksAsync(); // tra ve tat ca ca cuon sach
        public Task<BookModel> GetBookAsync(int id); //  tra ve mot cuon sach
        public Task<int> AddBookAsync(BookModel model); // tham sach
        public Task UpdateBookAsync(int id, BookModel model); // sua sach
        public Task DeleteBookAsync(int id); // xoa sach

    }
}
