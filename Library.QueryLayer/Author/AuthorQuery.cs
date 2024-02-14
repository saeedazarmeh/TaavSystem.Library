using Library.CommonLayer.Exeption;
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
        public Task<List<AuthorResultDTO>> GetAuthors();
        public Task<List<AuthorResultDTOByItsBooks>> GetAuthorsWithBooks();
        public Task<AuthorResultDTO> GetAuthorById(int authorId);
    }
    public class AuthorQuery:IAuthorQuery
    {
        private readonly IAuthorRepository _repository;

        public AuthorQuery(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<AuthorResultDTO>> GetAuthors()
        {
            var authors =await _repository.GetAllAsync();
            return authors.AuthorsMap();
        }
        public async Task<List<AuthorResultDTOByItsBooks>> GetAuthorsWithBooks()
        {
            var authors = await _repository.GetAllByItsBooksAsync();
            return authors.AuthorsMapByItsBooks();
        }
        public async Task<AuthorResultDTO> GetAuthorById(int authorId)
        {
            var author = await _repository.GetByIdAsync(authorId);
            if(author == null)
            {
                throw new NotFoundExeption("Data not found");
            }
            return author.AuthorMap();
        }
    }
}
