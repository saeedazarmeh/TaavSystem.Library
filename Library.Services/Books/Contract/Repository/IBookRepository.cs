using Library.Entities.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Books.Contract.Repository
{
    public interface IBookRepository
    {
        void Add(Book book);
        Task<List<Book>> GetAllAsync();
        Task<List<Book>> GetByNamrOrCategoryAsync(string name, string category);
        Task<Book> GetByIdAsync(int BookId);
        Task<Book> GetByIdWithDetailsAsync(int BookId);
        void Update(Book book);
        void Delete(Book book);
    }
}
