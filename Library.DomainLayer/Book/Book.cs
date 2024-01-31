using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DomainLayer.Book
{
    public class Book
    {
        public Book(DateTime publishYear, string author, string category, string name)
        {
            PublishYear = publishYear;
            Author = author;
            Category = category;
            Name = name;
        }

        public int Id { get;private set; }
        public DateTime PublishYear { get;private set; }
        public string Author { get;private set; }
        public string Name { get;private set; }
        public string Category { get;private set; }
        public void Edit(DateTime publishYear, string author, string category,string name)
        {
            if (publishYear != null)
            {
                PublishYear=publishYear;
            }
            if (author != null)
            {
                Author = author;
            }
            if (category != null)
            {
                Category = category;
            }
            if(name != null)
            {
                Name = name;
            }
        }
    }
}
