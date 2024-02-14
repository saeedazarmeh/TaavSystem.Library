
using Library.Contract.CommonServices;
using Library.Contract.Exeption;
using Library.Contract.UnitOfWork;
using Library.Entities.Author;
using Library.Services.Authors.Contracts.DTO;
using Library.Services.Authors.Contracts.Mapper;
using Library.Services.Authors.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Authors.Contracts
{
    public interface IAuthorService
    {
        Task AddAuthor(AuthorDTO authorDTO);
        Task UpdateAuthor(int authorId, AuthorDTO authorDTO);
        public Task<List<AuthorResultDTO>> GetAuthors();
        public Task<List<AuthorResultDTOByItsBooks>> GetAuthorsWithBooks();
        public Task<AuthorResultDTO> GetAuthorById(int authorId);
    }

    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;
        private readonly UnitOfWork _unit;

        public AuthorService(IAuthorRepository repository, UnitOfWork unit)
        {
            _repository = repository;
            _unit = unit;
        }

        public async Task AddAuthor(AuthorDTO authorDTO)
        {
            var author = new Author(authorDTO.Name.RemoveWhithSapases());
            _repository.Add(author);
            await _unit.Save();
        }

        public async Task UpdateAuthor(int authorId, AuthorDTO authorDTO)
        {
            var author = await _repository.GetByIdAsync(authorId);
            if (author == null)
            {
                throw new NotFoundExeption("Data not found");
            }
            author.Edit(authorDTO.Name);
            _repository.Update(author);
            await _unit.Save();

        }
        public async Task<List<AuthorResultDTO>> GetAuthors()
        {
            var authors = await _repository.GetAllAsync();
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
            if (author == null)
            {
                throw new NotFoundExeption("Data not found");
            }
            return author.AuthorMap();
        }
    }
}
