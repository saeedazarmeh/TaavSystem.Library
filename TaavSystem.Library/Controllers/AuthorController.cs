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
        public async Task<ApiResult> AddAuthor([FromBody] AuthorDTO authorDTO)
        {
            await _command.AddAuthor(authorDTO);
            return new ApiController().CommandResult();

        }

        [HttpGet("Get_All_Authors")]
        public async Task<ApiResult<List<AuthorResultDTO>>> GetAllAuthors()
        {
            var result=await _query.GetAuthors();
            return new ApiController().QueryResult<List<AuthorResultDTO>>(result);

        }

        [HttpGet("Get_All_Authors_whit _Its_Books")]
        public async Task<ApiResult<List<AuthorResultDTOByItsBooks>>> GetAllAuthorsWhithItsBooks()
        {
            var result =await _query.GetAuthorsWithBooks();
            return new ApiController().QueryResult<List<AuthorResultDTOByItsBooks>>(result);

        }
        [HttpGet("Get_Author/{authorId}")]
        public async Task<ApiResult<AuthorResultDTO>> GetAuthor([FromRoute] int authorId)
        {
            
            var result =await _query.GetAuthorById(authorId);
            return new ApiController().QueryResult<AuthorResultDTO>(result);

        }

        [HttpPost("Update_Author/{authorId}")]
        public async Task<ApiResult> UpdateAuthor([FromRoute] int authorId ,[FromBody] AuthorDTO authorDTO)
        {
            await _command.UpdateAuthor(authorId, authorDTO);
            return new ApiController().CommandResult();
        }
    }
}
