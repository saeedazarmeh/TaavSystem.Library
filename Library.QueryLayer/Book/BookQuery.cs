using Library.CommonLayer.Exeption;
using Library.DomainLayer.Book.Repository;
using Library.QueryLayer.DTO;
using Library.QueryLayer.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.QueryLayer.Book
{
    public interface IBookQuery
    {
        Task<List<BookResultDTO>> GetAllBook();
        Task<BookResultDTO> GetBookById(int bookId);
        Task<BookResultDTO> GetBookByIdWithDet(int bookId);
        Task<List<BookResultDTO>> GetFillteredBooks(BookFilltringtDTO book);
    }
    public class BookQuery : IBookQuery
    {
        private readonly IBookRepository _repository;

        public BookQuery(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BookResultDTO>> GetFillteredBooks(BookFilltringtDTO book)
        {
            var books=await _repository.GetByNamrOrCategoryAsync(book.Name,book.Category);
            return books.BooksMap();
        }

        public async Task<List<BookResultDTO>> GetAllBook()
        {
            var books =await _repository.GetAllAsync();
            return books.BooksMap();
        }
        public async Task<BookResultDTO> GetBookByIdWithDet(int bookId)
        {
            var book =await _repository.GetByIdWithDetailsAsync(bookId);
            if (book == null)
            {
                throw new NotFoundExeption("Data not found");
            }
            return book.BookMapWithDet();
        }

        public async Task<BookResultDTO> GetBookById(int bookId)
        {
            var book=await _repository.GetByIdAsync(bookId);
            if (book == null)
            {
                throw new NotFoundExeption("Data not found");
            }
            return book.BookMap();
        }
    }
}
