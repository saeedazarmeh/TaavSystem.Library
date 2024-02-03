using Library.DomainLayer.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DomainLayer.Author
{
    public class Author
    {
        public Author(string name)
        {
            Name = name;
        }

        public int Id { get;private set; }
        public string Name { get;private set; }
        public List<Book.Book> Books { get;private set; }=new List<Book.Book>();
        public void Edit(string name)
        {
            Name = name;
        }
    }
}
