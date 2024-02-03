using Library.DomainLayer.Book;
using Library.DomainLayer.Book.Repository;
using Library.DomainLayer.User;
using Library.InfraStuctureLayer.Persistent.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Library.InfraStuctureLayer.Repository
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

        public List<Book> GetAll()
        {
            return _dbContext.Books.Include(b => b.Category).Include(b => b.Author).ToList();
        }

        public Book GetById(int BookId)
        {
            return _dbContext.Books.FirstOrDefault(b => b.Id == BookId);
        }
        public Book GetByIdWithDetails(int BookId)
        {
            return _dbContext.Books.Include(b=>b.Category).Include(b=>b.Author).FirstOrDefault(b => b.Id == BookId);
        }

        public List<Book> GetByNamrOrCategory(string? name, string? category)
        {
            List<Book> filteredBooks= _dbContext.Books.Include(b=>b.Category).Include(b=>b.Author).ToList();
            if(name != null)
            {
               filteredBooks= filteredBooks.Where(b => b.Name == name).ToList();
            }
            if(category != null)
            {
                filteredBooks=filteredBooks.Where(b=>b.Category.Name==category).ToList();
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
        public void Save()
        {
            _dbContext.SaveChangesAsync();
        }
    }
}
