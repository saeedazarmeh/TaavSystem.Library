using Library.DomainLayer.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DomainLayer.Category
{
    public class Category
    {
        public Category(string name)
        {
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get;private set; }
        public List<Book.Book> Books { get; private set; } = new List<Book.Book>();

        public void Edit(string name)
        {
            Name=name;
        }
    }
}
