
using Library.Entities.Book;
using Library.Services.Books.Contract.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistant.Persistent.EF.Books
{
    public class BookRepository : IBookRepository
    {
        private EFDbContext _dbContext;
        public BookRepository(EFDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Book book)
        {
            _dbContext.Books.Add(book);
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _dbContext.Books.Include(b => b.Category).Include(b => b.Author).ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int BookId)
        {
            return await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == BookId);
        }
        public async Task<Book> GetByIdWithDetailsAsync(int BookId)
        {
            return await _dbContext.Books.Include(b => b.Category).Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == BookId);
        }

        public async Task<List<Book>> GetByNamrOrCategoryAsync(string? name, string? category)
        {
            List<Book> filteredBooks = await _dbContext.Books.Include(b => b.Category).Include(b => b.Author).ToListAsync();
            if (name != null)
            {
                filteredBooks = filteredBooks.Where(b => b.Name == name).ToList();
            }
            if (category != null)
            {
                filteredBooks = filteredBooks.Where(b => b.Category.Name == category).ToList();
            }
            return filteredBooks;

        }

        public void Update(Book book)
        {
            _dbContext.Books.Update(book);
        }
        public async void Delete(Book book)
        {
            _dbContext.Books.Remove(book);
        }
    }
}
