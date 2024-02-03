using Library.DomainLayer.Book.Repository;
using Library.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DomainLayer.Category.Repository;
using Library.DomainLayer.Author.Repository;

namespace Library.ApplicationLayer.Book
{
    public interface IBookCommand
    {
        public void AddBook(BookDTO bookDTO, int categoryId, int authorId);
        public void UpdateBook(int bookId, UpdateBookDTO updatebookDTO);
        public void UpdateBookCategory(int bookId, int categoryId);
        public void UpdateBookAuthor(int bookId, int authorId);
        public void DeleteBook(int bookId);
    }

    public class BookCommand : IBookCommand
    {
        private readonly IBookRepository _booRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAuthorRepository _authorRepository;
        public BookCommand(IBookRepository repository, ICategoryRepository categoryRepository, IAuthorRepository authorRepository)
        {
            _booRepository = repository;
            _categoryRepository=categoryRepository;
            _authorRepository=authorRepository; 
        }
        public void AddBook(BookDTO bookDTO , int categoryId, int authorId)
        {
            var book = new DomainLayer.Book.Book(bookDTO.PublishYear,  bookDTO.Name);
            var category=_categoryRepository.GetById(categoryId);
            var author=_authorRepository.GetById(authorId);
            _booRepository.Add(book);
            book.AddOrEditCategory(category);
            book.AddOrEditAuthor(author);
            _booRepository.Save();
        }
        public void UpdateBook(int bookId, UpdateBookDTO updatebookDTO)
        {
            var book = _booRepository.GetById(bookId);
           if(book != null)
            {
                book.Edit(updatebookDTO.PublishYear,  updatebookDTO.Name);
                _booRepository.Update(book);
                _booRepository.Save();
            }
        }
        public void UpdateBookCategory(int bookId, int categoryId)
        {
            var book = _booRepository.GetById(bookId);
            if (book != null)
            {
                var category=_categoryRepository.GetById(categoryId);
                book.AddOrEditCategory(category);
                _booRepository.Update(book);
                _booRepository.Save();
            }
        }
        public void UpdateBookAuthor(int bookId, int authorId)
        {
            var book = _booRepository.GetById(bookId);
            if (book != null)
            {
                var author = _authorRepository.GetById(authorId);
                book.AddOrEditAuthor(author);
                _booRepository.Update(book);
                _booRepository.Save();
            }
        }
        public void DeleteBook(int bookId)
        {
            var book =_booRepository.GetById(bookId);
            if (book != null)
            {
                _booRepository.Delete(book);
                _booRepository.Save();
            }
        }
    }
}
