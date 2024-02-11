using Library.CommonLayer.Result;
using Library.DomainLayer.Author;
using Library.DomainLayer.Author.Repository;
using Library.DomainLayer.Category.Repository;
using Library.QueryLayer.DTO;
using Library.QueryLayer.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.QueryLayer.Author
{
    public interface IAuthorQuery
    {
        public OperationResult<List<AuthorResultDTO>> GetAuthors();
        public OperationResult<List<AuthorResultDTOByItsBooks>> GetAuthorsWithBooks();
        public OperationResult<AuthorResultDTO> GetAuthorById(int authorId);
    }
    public class AuthorQuery:IAuthorQuery
    {
        private readonly IAuthorRepository _repository;

        public AuthorQuery(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public OperationResult<List<AuthorResultDTO>> GetAuthors()
        {
            var authors = _repository.GetAll();
            return OperationResult<List<AuthorResultDTO>>
                .Success(authors.AuthorsMap(),"Data uploded successfully");
        }
        public OperationResult<List<AuthorResultDTOByItsBooks>> GetAuthorsWithBooks()
        {
            var authors = _repository.GetAll();
            return OperationResult<List<AuthorResultDTOByItsBooks>>
                .Success(authors.AuthorsMapByItsBooks(), "Data uploded successfully");

        }
        public OperationResult<AuthorResultDTO> GetAuthorById(int authorId)
        {
            var author = _repository.GetById(authorId);
            if(author == null)
            {
                return OperationResult<AuthorResultDTO>.NotFound();
            }
            return OperationResult<AuthorResultDTO>
              .Success(author.AuthorMap(), "Data uploded successfully");
        }
    }
}
