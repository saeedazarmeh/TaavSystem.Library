using Library.DomainLayer.Book.Repository;
using Library.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DomainLayer.Category.Repository;
using Library.DomainLayer.Author.Repository;
using Library.DomainLayer.Author;
using Library.CommonLayer.UnitOfWork;
using Library.CommonLayer.Exeption;
using Library.CommonLayer.CommonServices;

namespace Library.ApplicationLayer.Book
{
    public interface IBookCommand
    {
        public Task AddBook(BookDTO bookDTO, int categoryId, int authorId);
        public Task UpdateBook(int bookId, UpdateBookDTO updatebookDTO);
        public Task UpdateBookCategory(int bookId, int categoryId);
        public Task UpdateBookCount(int bookId, int addedBook);
        public Task UpdateBookAuthor(int bookId, int authorId);
        public Task DeleteBook(int bookId);
    }

    public class BookCommand : IBookCommand
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly UnitOfWork _unit;
        public BookCommand(IBookRepository repository, ICategoryRepository categoryRepository,
            IAuthorRepository authorRepository,UnitOfWork unit)
        {
            _bookRepository = repository;
            _unit = unit;   
            _categoryRepository=categoryRepository;
            _authorRepository=authorRepository; 
        }
        public async Task AddBook(BookDTO bookDTO , int categoryId, int authorId )
        {
            var book = new DomainLayer.Book.Book(bookDTO.PublishYear,  bookDTO.Name.RemoveWhithSapases(), bookDTO.bookCount);
            var category=await _categoryRepository.GetByIdAsync(categoryId);
            var author=await _authorRepository.GetByIdAsync(authorId);
            if (category == null || author == null)
            {
                throw new NotFoundExeption("Data not found");
            }
            await _unit.Begin();
            try
            {
                _bookRepository.Add(book);
                book.AddOrEditCategory(category);
                book.AddOrEditAuthor(author);
                await _unit.Save();
                await _unit.Commit();
            }
            catch(Exception ex)
            {
                _unit.RoleBack();
            }
      
        }
        public async Task UpdateBook(int bookId, UpdateBookDTO updatebookDTO)
        {
            var book =await _bookRepository.GetByIdAsync(bookId);
           if(book == null)
            {
                throw new NotFoundExeption("Data not found");
            }
            book.Edit(updatebookDTO.PublishYear, updatebookDTO.Name.RemoveWhithSapases());
            _bookRepository.Update(book);
            await _unit.Save();
        }
        public async Task UpdateBookCategory(int bookId, int categoryId)
        {
            var book =await _bookRepository.GetByIdAsync(bookId);
            if (book == null)
            {
                throw new NotFoundExeption("Data not found");
            }
            var category =await _categoryRepository.GetByIdAsync(categoryId);
            if (category == null)
            {
                throw new NotFoundExeption("Data not found");
            }
            book.AddOrEditCategory(category);
            _bookRepository.Update(book);
            await _unit.Save();
        }
        public async Task UpdateBookAuthor(int bookId, int authorId)
        {
            var book =await _bookRepository.GetByIdAsync(bookId);
            if (book == null)
            {
                throw new NotFoundExeption("Data not found");
            }
            var author =await _authorRepository.GetByIdAsync(authorId);
            if (author == null)
            {
                throw new NotFoundExeption("Data not found");
            }
            book.AddOrEditAuthor(author);
                _bookRepository.Update(book);
                await _unit.Save();
            
        }
        public async Task DeleteBook(int bookId)
        {
            var book =await _bookRepository.GetByIdAsync(bookId);
            if (book == null)
            {
                throw new NotFoundExeption("Data not found");
            }
            _bookRepository.Delete(book);
                await _unit.Save();
        }

        public async Task UpdateBookCount(int bookId, int newBookcount)
        {
            var book =await _bookRepository.GetByIdAsync(bookId);
            if (book == null)
            {
                throw new NotFoundExeption("Data not found");
            }
            var newcount = book.BookCount + newBookcount;
            if (newcount < 0)
            {
                throw new InvalidDataException("total count cant be less than zero");
            }
            book.AddOrDecreaseBookCount(newcount);
                _bookRepository.Update(book);
                await _unit.Save();
        }
    }
}
