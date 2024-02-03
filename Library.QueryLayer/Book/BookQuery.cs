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
        List<BookResultDTO> GetAllBook();
        BookResultDTO GetBookById(int bookId);
        BookResultDTO GetBookByIdWithDet(int bookId);
        List<BookResultDTO> GetFillteredBooks(BookFilltringtDTO book);
    }
    public class BookQuery : IBookQuery
    {
        private readonly IBookRepository _repository;

        public BookQuery(IBookRepository repository)
        {
            _repository = repository;
        }

        public List<BookResultDTO> GetFillteredBooks(BookFilltringtDTO book)
        {
            var books=_repository.GetByNamrOrCategory(book.Name,book.Category);
            return books.BooksMap();
        }

        public List<BookResultDTO> GetAllBook()
        {
            var books = _repository.GetAll();
            return books.BooksMap();
        }
        public BookResultDTO GetBookByIdWithDet(int bookId)
        {
            var book = _repository.GetByIdWithDetails(bookId);
            return book.BookMapWithDet();
        }

        public BookResultDTO GetBookById(int bookId)
        {
            var book=_repository.GetById(bookId);
            return book.BookMap();
        }
    }
}
