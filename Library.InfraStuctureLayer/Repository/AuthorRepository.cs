using Library.DomainLayer.Author;
using Library.DomainLayer.Author.Repository;
using Library.DomainLayer.Category;
using Library.InfraStuctureLayer.Persistent.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.InfraStuctureLayer.Repository
{
    public class AuthorRepository:IAuthorRepository
    {

        private readonly EFDbContext _dbContext;

        public AuthorRepository(EFDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Author author)
        {
            _dbContext.Authors.Add(author);
        }

        List<Author> IAuthorRepository.GetAll()
        {
            return _dbContext.Authors.ToList();
        }

        List<Author> IAuthorRepository.GetAllByItsBooks()
        {
            return _dbContext.Authors.Include(c => c.Books).ToList();
        }

        Author IAuthorRepository.GetById(int authorId)
        {
            return _dbContext.Authors.FirstOrDefault(c => c.Id == authorId);
        }

        public void Update(Author author)
        {
            _dbContext.Authors.Update(author);
        }


        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
