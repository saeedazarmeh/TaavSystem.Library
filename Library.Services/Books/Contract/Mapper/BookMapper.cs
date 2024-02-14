using Library.Entities.Book;
using Library.Services.Books.Contract.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Books.Contract.Mapper
{
    internal static class BookMapper
    {
        public static List<BookResultDTO> BooksMap(this List<Book> books)
        {
            var booksResultDTO = new List<BookResultDTO>();
            foreach (var book in books)
            {
                booksResultDTO.Add(new BookResultDTO()
                {
                    BookId = book.Id,
                    PublishYear = book.PublishYear,
                    Author = book.Author.Name,
                    Category = book.Category.Name,
                    Name = book.Name,
                });
            }
            return booksResultDTO;
        }
        public static BookResultDTO BookMapWithDet(this Book book)
        {
            var bookResultDTO = new BookResultDTO()
            {
                BookId = book.Id,
                Author = book.Author.Name,
                Category = book.Category.Name,
                PublishYear = book.PublishYear,
                Name = book.Name,
            };
            return bookResultDTO;
        }
        public static BookResultDTO BookMap(this Book book)
        {
            var bookResultDTO = new BookResultDTO()
            {
                BookId = book.Id,
                PublishYear = book.PublishYear,
                Name = book.Name,
            };
            return bookResultDTO;
        }
    }
}
