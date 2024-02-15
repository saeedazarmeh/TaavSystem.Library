using Library.Entities.Category;
using Library.Persistant.Persistent.EF;
using Library.Services.Categories.Contract.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistant.Persistent.EF.Categories
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
            return await _dbContext.Categories.Include(c => c.Books).ThenInclude(b =>b.Author).ToListAsync();
        }

        public void Update(Category category)
        {
            _dbContext.Categories.Update(category);
        }
    }
}
