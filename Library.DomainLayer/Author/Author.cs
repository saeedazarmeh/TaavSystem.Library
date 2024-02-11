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
            Gaurd(name);
            Name = name;
        }

        public int Id { get;private set; }
        public string Name { get;private set; }
        public List<Book.Book> Books { get;private set; }=new List<Book.Book>();
        public void Edit(string name)
        {
            Gaurd(name);
            Name = name;
        }
        public void Gaurd(string name)
        {
            if(name==null)
            {
                throw new InvalidDataException("name couldn't be null") ;
            }
            else if (name.Length > 80)
            {
                throw new InvalidDataException("Length of Name Should be less than 80 char");
            }
        }
    }
}
