using AutoMapper;
using WebAPI_free.Data;
using WebAPI_free.Models;

namespace WebAPI_free.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Book, BookModel>().ReverseMap(); // mapper ca hai chieuf
        }
    }
}
