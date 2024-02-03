using Library.DomainLayer.Book;
using Library.QueryLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.QueryLayer.Mapper
{
    internal static class BookMapper
    {
        public static List<BookResultDTO> BooksMap(this List<DomainLayer.Book.Book> books)
        {
            var booksResultDTO=new List<BookResultDTO>();
            foreach (var book in books)
            {
                booksResultDTO.Add(new BookResultDTO()
                {
                    PublishYear = book.PublishYear,
                    Author = book.Author.Name,
                    Category = book.Category.Name,
                    Name = book.Name,
                });
            }
            return booksResultDTO;
        }
        public static BookResultDTO BookMapWithDet(this DomainLayer.Book.Book book)
        {
            var bookResultDTO =new BookResultDTO() 
            {

                Author = book.Author.Name,
                Category = book.Category.Name,
                PublishYear = book.PublishYear,
                Name = book.Name,
            };
            return bookResultDTO;
        }
        public static BookResultDTO BookMap(this DomainLayer.Book.Book book)
        {
            var bookResultDTO = new BookResultDTO()
            {
                PublishYear = book.PublishYear,
                Name = book.Name,
            };
            return bookResultDTO;
        }
    }
}
