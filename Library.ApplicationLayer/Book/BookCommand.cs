using Library.DomainLayer.Book.Repository;
using Library.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ApplicationLayer.Book
{
    public interface IBookCommand
    {
        void AddBook(BookDTO bookDTO);
        void UpdateBook(UpdateBookDTO updatebookDTO);
        void DeleteBook(int bookId);
    }

    public class BookCommand : IBookCommand
    {
        private readonly IBookRepository _repository;
        public BookCommand(IBookRepository repository)
        {
            _repository = repository;
        }
        public void AddBook(BookDTO bookDTO)
        {
            var book = new DomainLayer.Book.Book(bookDTO.PublishYear, bookDTO.Author, bookDTO.Category, bookDTO.Name);
            _repository.Add(book);
            _repository.Save();
        }
        public void UpdateBook(UpdateBookDTO updatebookDTO)
        {
            var book = _repository.GetById(updatebookDTO.Id);
           if(book != null)
            {
                book.Edit(updatebookDTO.PublishYear, updatebookDTO.Author, updatebookDTO.Category, updatebookDTO.Name);
                _repository.Update(book);
                _repository.Save();
            }
        }
        public void DeleteBook(int bookId)
        {
            var book =_repository.GetById(bookId);
            if (book != null)
            {
                _repository.Delete(book);
                _repository.Save();
            }
        }
    }
}
