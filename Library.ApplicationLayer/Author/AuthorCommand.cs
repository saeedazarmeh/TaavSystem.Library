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
using Library.CommonLayer.UnitOfWork;
using Library.CommonLayer.CommonServices;

namespace Library.ApplicationLayer.Author
{
    public interface IAuthorCommand
    {
        Task AddAuthor(AuthorDTO authorDTO);
        Task UpdateAuthor(int authorId, AuthorDTO authorDTO);
    }

    public class AuthorCommand : IAuthorCommand
    {
        private readonly IAuthorRepository _repository;
        private readonly UnitOfWork _unit;

        public AuthorCommand(IAuthorRepository repository,UnitOfWork unit)
        {
            _repository = repository;
            _unit = unit;
        }

        public async Task AddAuthor(AuthorDTO authorDTO)
        {
            var author = new DomainLayer.Author.Author(authorDTO.Name.RemoveWhithSapases());
            _repository.Add(author);
            await _unit.Save();
        }

        public async Task UpdateAuthor(int authorId, AuthorDTO authorDTO)
        {
            var author =await _repository.GetByIdAsync(authorId);
            if (author == null)
            {
                throw new NotFoundExeption("Data not found");
            }
             author.Edit(authorDTO.Name);
             _repository.Update(author);
            await _unit.Save();

        }
    }
}
