using Library.Services.Books.Contract.DTO;

namespace Library.Services.Books.Contract
{
    public interface IBookService
    {
        public Task AddBook(BookDTO bookDTO, int categoryId, int authorId);
        public Task UpdateBook(int bookId, UpdateBookDTO updatebookDTO);
        public Task UpdateBookCategory(int bookId, int categoryId);
        public Task UpdateBookCount(int bookId, int addedBook);
        public Task UpdateBookAuthor(int bookId, int authorId);
        public Task DeleteBook(int bookId);
        Task<List<BookResultDTO>> GetAllBook();
        Task<BookResultDTO> GetBookById(int bookId);
        Task<BookResultDTO> GetBookByIdWithDet(int bookId);
        Task<List<BookResultDTO>> GetFillteredBooks(BookFilltringtDTO book);
    }
}
