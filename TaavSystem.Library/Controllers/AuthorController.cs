using Library.Services.Authors.Contracts;
using Library.Services.Authors.Contracts.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaavSystem.Library.Utilities.Result;

namespace TaavSystem.Library.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _service;

        public AuthorController(IAuthorService service)
        {
            _service = service;
        }

        [HttpPost("Add_Author")]
        public async Task<ApiResult> AddAuthor([FromBody] AuthorDTO authorDTO)
        {
            await _service.AddAuthor(authorDTO);
            return new ApiController().CommandResult();

        }

        [HttpGet("Get_All_Authors")]
        public async Task<ApiResult<List<AuthorResultDTO>>> GetAllAuthors()
        {
            var result=await _service.GetAuthors();
            return new ApiController().QueryResult<List<AuthorResultDTO>>(result);

        }

        [HttpGet("Get_All_Authors_whit _Its_Books")]
        public async Task<ApiResult<List<AuthorResultDTOByItsBooks>>> GetAllAuthorsWhithItsBooks()
        {
            var result =await _service.GetAuthorsWithBooks();
            return new ApiController().QueryResult<List<AuthorResultDTOByItsBooks>>(result);

        }
        [HttpGet("Get_Author/{authorId}")]
        public async Task<ApiResult<AuthorResultDTO>> GetAuthor([FromRoute] int authorId)
        {
            
            var result =await _service.GetAuthorById(authorId);
            return new ApiController().QueryResult<AuthorResultDTO>(result);

        }

        [HttpPost("Update_Author/{authorId}")]
        public async Task<ApiResult> UpdateAuthor([FromRoute] int authorId ,[FromBody] AuthorDTO authorDTO)
        {
            await _service.UpdateAuthor(authorId, authorDTO);
            return new ApiController().CommandResult();
        }
    }
}
