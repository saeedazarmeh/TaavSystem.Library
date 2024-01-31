using Library.ApplicationLayer.Book;
using Library.QueryLayer.Book;
using Library.QueryLayer.DTO;
using Microsoft.AspNetCore.Mvc;

namespace TaavSystem.Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookCommand _command;
        private readonly IBookQuery _query;

        public BookController(IBookCommand command, IBookQuery query)
        {
            _command = command;
            _query = query;
        }
        [HttpPost("Add_Book")]
        public void AddBook([FromBody] BookDTO Book)
        {
            _command.AddBook(Book);
        }

        [HttpGet("Get_All_Books")]
        public List<BookResultDTO> GetAllBooks()
        {
            return _query.GetAllBook();
        }

        [HttpGet("Get_Filltered_Books")]
        public List<BookResultDTO> GetFillterBooks([FromQuery] BookFilltringtDTO Book)
        {
            return _query.GetFillteredBooks(Book);
        }

        [HttpGet("Get_Book_ById")]
        public BookResultDTO GetBookById([FromQuery] int BookId)
        {
            return _query.GetBookById(BookId);
        }

        [HttpPatch("Update_Book")]
        public void UpdateBook([FromBody] UpdateBookDTO updateBookDTO)
        {
            _command.UpdateBook(updateBookDTO);
        }

        [HttpDelete("Delete_Book")]
        public void DeleteBook([FromQuery] int BookId)
        {
            _command.DeleteBook(BookId);
        }
    }
}
