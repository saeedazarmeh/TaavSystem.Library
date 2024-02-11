using Library.ApplicationLayer.Author;
using Library.CommonLayer.Result;
using Library.DomainLayer.Author;
using Library.QueryLayer.Author;
using Library.QueryLayer.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaavSystem.Library.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorCommand _command;
        private readonly IAuthorQuery _query;

        public AuthorController(IAuthorCommand command, IAuthorQuery query)
        {
            _command = command;
            _query = query;
        }

        [HttpPost("Add_Author")]
        public ApiResult AddAuthor([FromBody] AuthorDTO authorDTO)
        {
            var result=_command.AddAuthor(authorDTO);
            HttpContext.Response.StatusCode = (int)result.Status;
            return new ApiController().CommandResult(result);

        }

        [HttpGet("Get_All_Authors")]
        public ApiResult<List<AuthorResultDTO>> GetAllAuthors()
        {
            var result=_query.GetAuthors();
            HttpContext.Response.StatusCode = (int)result.Status;
            return new ApiController().QueryResult<List<AuthorResultDTO>>(result);

        }

        [HttpGet("Get_All_Authors_whit _Its_Books")]
        public ApiResult<List<AuthorResultDTOByItsBooks>> GetAllAuthorsWhithItsBooks()
        {
            var result = _query.GetAuthorsWithBooks();
            HttpContext.Response.StatusCode = (int)result.Status;
            return new ApiController().QueryResult<List<AuthorResultDTOByItsBooks>>(result);

        }
        [HttpGet("Get_Author/{authorId}")]
        public ApiResult<AuthorResultDTO> GetAuthor([FromRoute] int authorId)
        {
            
            var result = _query.GetAuthorById(authorId);
            HttpContext.Response.StatusCode=(int)result.Status;
            return new ApiController().QueryResult<AuthorResultDTO>(result);

        }

        [HttpPost("Update_Author/{authorId}")]
        public ApiResult UpdateAuthor([FromRoute] int authorId ,[FromBody] AuthorDTO authorDTO)
        {
            var result = _command.UpdateAuthor(authorId, authorDTO);
            HttpContext.Response.StatusCode = (int)result.Status;
            return new ApiController().CommandResult(result);
        }
    }
}
