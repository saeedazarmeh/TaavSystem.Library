using Library.Entities.Author;
using Library.Services.Authors.Contracts.DTO;
using Library.Services.Books.Contract.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Authors.Contracts.Mapper
{
    public static class AuthorMapper
    {
        public static List<AuthorResultDTO> AuthorsMap(this List<Author> authors)
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
        public static List<AuthorResultDTOByItsBooks> AuthorsMapByItsBooks(this List<Author> authors)
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
        public static AuthorResultDTO AuthorMap(this Author author)
        {
            return new AuthorResultDTO()
            {
                AuthorId = author.Id,
                Name = author.Name,
            };
        }
    }
}
