using Library.DomainLayer.Author;
using Library.QueryLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.QueryLayer.Mapper
{
    public static class AuthorMapper
    {
        public static List<AuthorResultDTO> AuthorsMap(this List<DomainLayer.Author.Author> authors)
        {
            var authorsDTO = new List<AuthorResultDTO>();
            foreach (var author in authors)
            {
                authorsDTO.Add(new AuthorResultDTO()
                {
                    AuthorId = author.Id,
                    Name = author.Name
                });
            }
            return authorsDTO;
        }
        public static List<AuthorResultDTOByItsBooks> AuthorsMapByItsBooks(this List<DomainLayer.Author.Author> authors)
        {
            var authorsDTO = new List<AuthorResultDTOByItsBooks>();
            foreach (var author in authors)
            {
                authorsDTO.Add(new AuthorResultDTOByItsBooks()
                {
                    AuthorId = author.Id,
                    Name = author.Name,
                    Books = author.Books.BooksMap()
                });

            }
            return authorsDTO;
        }
        public static AuthorResultDTO AuthorMap(this DomainLayer.Author.Author author)
        {
            return new AuthorResultDTO()
            {
                AuthorId = author.Id,
                Name = author.Name,
            };
        }
    }
}
