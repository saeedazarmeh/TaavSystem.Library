using Library.ApplicationLayer.Author;
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
        public void AddAuthor([FromBody] AuthorDTO authorDTO)
        {
            _command.AddAuthor(authorDTO);

        }

        [HttpGet("Get_All_Authors")]
        public List<AuthorResultDTO> GetAllAuthors()
        {
            var authors=_query.GetAuthors();
            return authors;

        }

        [HttpGet("Get_All_Authors_whit _Its_Books")]
        public List<AuthorResultDTOByItsBooks> GetAllAuthorsWhithItsBooks()
        {
            var authors = _query.GetAuthorsWithBooks();
            return authors;

        }
        [HttpGet("Get_Author/{authorId}")]
        public AuthorResultDTO GetAuthor([FromRoute] int authorId)
        {
            var authors = _query.GetAuthorById(authorId);
            return authors;

        }

        [HttpPost("Update_Author/{authorId}")]
        public void UpdateAuthor([FromRoute] int authorId ,[FromBody] AuthorDTO authorDTO)
        {
            _command.UpdateAuthor(authorId, authorDTO);

        }
    }
}
