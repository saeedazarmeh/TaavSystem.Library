using Library.Services.Books.Contract;
using Library.Services.Books.Contract.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TaavSystem.Library.Utilities.Result;

namespace TaavSystem.Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpPost("Define_Book")]
        public async Task<ApiResult> DefineBook([FromQuery]int categoryId,int authorId, [FromBody] BookDTO Book)
        {
            await _service.AddBook(Book,categoryId,authorId);
            return new ApiController().CommandResult();
        }

        [HttpGet("Get_All_Books")]
        public async Task<ApiResult<List<BookResultDTO>>> GetAllBooks()
        {
            var result = await _service.GetAllBook();
            return new ApiController().QueryResult< List < BookResultDTO >>(result);

        }

        [HttpGet("Get_Filltered_Books")]
        public async Task<ApiResult<List<BookResultDTO>>> GetFillterBooks( [FromQuery] BookFilltringtDTO Book)
        {
            var result=await _service.GetFillteredBooks(Book);
            return new ApiController().QueryResult<List<BookResultDTO>>(result);

        }

        [HttpGet("Get_Book_ById/{bookId}")]
        public async Task<ApiResult<BookResultDTO>> GetBookById([FromRoute] int bookId)
        {
            var result = await _service.GetBookById(bookId);
            return new ApiController().QueryResult<BookResultDTO>(result);
        }

        [HttpGet("Get_Book_ById_WithDet/{bookId}")]
        public async Task<ApiResult<BookResultDTO>> GetBookByIdWithCategoryAndAuthor([FromRoute] int bookId)
        {
            var result =await _service.GetBookByIdWithDet(bookId);
            return new ApiController().QueryResult<BookResultDTO>(result);
        }

        [HttpPatch("Update_Book/{bookId}")]
        public async Task<ApiResult> UpdateBook([FromRoute] int bookId, [FromBody] UpdateBookDTO updateBookDTO)
        {
            await _service.UpdateBook(bookId, updateBookDTO);
            return new ApiController().CommandResult();
        }

        [HttpPatch("Add_Or_Decrease_Book_Numbers/{bookId}")]
        public async Task<ApiResult> AddOrDecreaseBookNumbers([FromRoute] int bookId, [FromQuery] int addedOrDecreaseNumbers)
        {
            await _service.UpdateBookCount(bookId, addedOrDecreaseNumbers);
            return new ApiController().CommandResult();
        }

        [HttpDelete("Delete_Book/{bookId}")]
        public async Task<ApiResult> DeleteBook([FromRoute] int bookId)
        {
            await _service.DeleteBook(bookId);
            return new ApiController().CommandResult();
        }
    }
}
