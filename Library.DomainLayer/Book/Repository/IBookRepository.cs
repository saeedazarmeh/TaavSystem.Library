using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DomainLayer.Book.Repository
{
    public interface IBookRepository
    {
        void Add(Book book);
        List<Book> GetAll();
        List<Book> GetByNamrOrCategory(string name,string category);
        Book GetById(int BookId);
        void Update(Book book);
        void Delete(Book book);
        void Save();
    }
}
