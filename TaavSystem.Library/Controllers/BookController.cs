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

        [HttpPost("Define_Book")]
        public void DefineBook([FromQuery]int categoryId,int authorId, [FromBody] BookDTO Book)
        {
            _command.AddBook(Book,categoryId,authorId);
        }

        [HttpGet("Get_All_Books")]
        public List<BookResultDTO> GetAllBooks()
        {
            return _query.GetAllBook();
        }

        [HttpGet("Get_Filltered_Books")]
        public List<BookResultDTO> GetFillterBooks( [FromQuery] BookFilltringtDTO Book)
        {
            return _query.GetFillteredBooks(Book);
        }

        [HttpGet("Get_Book_ById/{bookId}")]
        public BookResultDTO GetBookById([FromRoute] int bookId)
        {
            return _query.GetBookById(bookId);
        }

        [HttpGet("Get_Book_ById_WithDet/{bookId}")]
        public BookResultDTO GetBookByIdWithCategoryAndAuthor([FromRoute] int bookId)
        {
            return _query.GetBookByIdWithDet(bookId);
        }

        [HttpPatch("Update_Book/{bookId}")]
        public void UpdateBook([FromRoute] int bookId, [FromBody] UpdateBookDTO updateBookDTO)
        {
            _command.UpdateBook(bookId, updateBookDTO);
        }

        [HttpPatch("Add_Book_Numbers/{bookId}")]
        public void AddBookNumber([FromRoute] int bookId, [FromBody] int addedNumbers)
        {
            _command.UpdateBookCount(bookId,addedNumbers);
        }

        [HttpDelete("Delete_Book/{bookId}")]
        public void DeleteBook([FromRoute] int bookId)
        {
            _command.DeleteBook(bookId);
        }
    }
}
