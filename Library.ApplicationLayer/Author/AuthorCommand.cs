using Library.ApplicationLayer.Book;
using Library.DomainLayer.Author.Repository;
using Library.DomainLayer.Category;
using Library.CommonLayer.Exeption;
using Library.DomainLayer.Category.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.CommonLayer.Result;

namespace Library.ApplicationLayer.Author
{
    public interface IAuthorCommand
    {
        OperationResult AddAuthor(AuthorDTO authorDTO);
        OperationResult UpdateAuthor(int authorId, AuthorDTO authorDTO);
    }

    public class AuthorCommand : IAuthorCommand
    {
        private readonly IAuthorRepository _repository;

        public AuthorCommand(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public OperationResult AddAuthor(AuthorDTO authorDTO)
        {
            var author = new DomainLayer.Author.Author(authorDTO.Name);
            _repository.Add(author);
            _repository.Save();
            return OperationResult.Success("Added successfully");
        }

        public OperationResult UpdateAuthor(int authorId, AuthorDTO authorDTO)
        {
            var author = _repository.GetById(authorId);
            if (author == null)
            {
                return OperationResult.NotFound("Data not found");
            }
            author.Edit(authorDTO.Name);
            _repository.Update(author);
            _repository.Save();
            return OperationResult.Success("Updated successfully");

        }
    }
}
