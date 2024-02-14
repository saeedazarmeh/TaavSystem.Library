using Library.DomainLayer.Category;
using Library.DomainLayer.Category.Repository;
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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EFDbContext _dbContext;

        public CategoryRepository(EFDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Category category)
        {
            _dbContext.Categories.Add(category);
        }

        public async Task<Category> GetByIdAsync(int categoryId)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<List<Category>> GetAllByItsBooksAsync()
        {
            return await _dbContext.Categories.Include(c => c.Books).ToListAsync();
        }

        public void Update(Category category)
        {
            _dbContext.Categories.Update(category);
        }
    }
}
