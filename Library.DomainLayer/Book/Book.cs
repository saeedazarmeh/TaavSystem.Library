﻿
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
        public Book(DateTime publishYear ,  string name)
        {
            PublishYear = publishYear;
            Name = name;
        }

        public int Id { get;private set; }
        public string Name { get; private set; }
        public DateTime PublishYear { get;private set; }
        [ForeignKey("Author")]
        public int AuthorId { get;private set; }
    
        public virtual Author.Author Author { get;private set; }
        [ForeignKey("Category")]
        public int CategoryId { get;private set; }
      
        public virtual Category.Category Category { get;private set; }
        public HashSet<BorrowBook> BorrowBooks { get;private set; }
        public void Edit(DateTime publishYear, string name)
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
        public void AddOrEditCategory(Category.Category category)
        {
            Category=category;
        }
        public void AddOrEditAuthor(Author.Author author)
        {
            Author = author;
        }
    }
}
