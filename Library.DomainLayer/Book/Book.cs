
using Library.DomainLayer.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DomainLayer.Book
{
    public class Book
    {
        public Book(string publishYear ,  string name,int bookCount)
        {
            PublishYear = publishYear;
            Name = name;
            BookCount=bookCount;
        }

        public int Id { get;private set; }
        public string Name { get; private set; }
        public int BookCount { get; private set; }
        public string PublishYear { get;private set; }
        [ForeignKey("Author")]
        public int AuthorId { get;private set; }
    
        public virtual Author.Author Author { get;private set; }
        [ForeignKey("Category")]
        public int CategoryId { get;private set; }
      
        public virtual Category.Category Category { get;private set; }
        public List<BorrowBook> BorrowBooks { get;private set; }
        public void Edit(string publishYear, string name)
        {
            if (publishYear != null)
            {
                PublishYear=publishYear;
            }
            if(name != null)
            {
                Name = name;
            }
        }
        public void AddOrDecreaseBookCount(int newCount)
        {
            BookCount = newCount;
        }
        public void AddOrEditCategory(Category.Category category)
        {
            Category = category;
        }
        public void AddOrEditAuthor(Author.Author author)
        {
            Author = author;
        }
    }
}
