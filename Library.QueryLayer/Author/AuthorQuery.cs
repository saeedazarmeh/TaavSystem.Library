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
        public List<AuthorResultDTO> GetAuthors();
        public List<AuthorResultDTOByItsBooks> GetAuthorsWithBooks();
        public AuthorResultDTO GetAuthorById(int authorId);
    }
    public class AuthorQuery:IAuthorQuery
    {
        private readonly IAuthorRepository _repository;

        public AuthorQuery(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public List<AuthorResultDTO> GetAuthors()
        {
            var authors = _repository.GetAll();
            return authors.CategoriesMap();
        }
        public List<AuthorResultDTOByItsBooks> GetAuthorsWithBooks()
        {
            var authors = _repository.GetAll();
            return authors.CategoriesMapByItsBooks();
        }
        public AuthorResultDTO GetAuthorById(int authorId)
        {
            var author = _repository.GetById(authorId);
            return author.CategoryMap();
        }
    }
}
