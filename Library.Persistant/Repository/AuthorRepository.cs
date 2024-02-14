using Library.DomainLayer.Author;
using Library.DomainLayer.Author.Repository;
using Library.DomainLayer.Category;
using Library.InfraStuctureLayer.Persistent.EF;
using Library.Persistant.Persistent.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistant.Repository
{
    public class AuthorRepository : IAuthorRepository
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

        public async Task<List<Author>> GetAllAsync()
        {
            return await _dbContext.Authors.ToListAsync();
        }

        public Task<List<Author>> GetAllByItsBooksAsync()
        {
            return _dbContext.Authors.Include(c => c.Books).ToListAsync();
        }

        public async Task<Author> GetByIdAsync(int authorId)
        {
            return await _dbContext.Authors.FirstOrDefaultAsync(c => c.Id == authorId);
        }

        public void Update(Author author)
        {
            _dbContext.Authors.Update(author);
        }
    }
}
