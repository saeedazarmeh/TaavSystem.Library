using Library.Services.Authors.Contracts.DTO;

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
}
