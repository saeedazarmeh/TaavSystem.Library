using Library.ApplicationLayer.Book;
using Library.DomainLayer.Author.Repository;
using Library.DomainLayer.Category;
using Library.DomainLayer.Category.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ApplicationLayer.Author
{
    public interface IAuthorCommand
    {
        void AddAuthor(AuthorDTO authorDTO);
        void UpdateAuthor(int authorId, AuthorDTO authorDTO);
    }

    public class AuthorCommand : IAuthorCommand
    {
        private readonly IAuthorRepository _repository;

        public AuthorCommand(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public void AddAuthor(AuthorDTO authorDTO)
        {
            var author = new DomainLayer.Author.Author(authorDTO.Name);
            _repository.Add(author);
            _repository.Save();
        }

        public void UpdateAuthor(int authorId, AuthorDTO authorDTO)
        {
            var author = _repository.GetById(authorId);
            author.Edit(authorDTO.Name);
            _repository.Update(author);
            _repository.Save();
        }
    }
}
