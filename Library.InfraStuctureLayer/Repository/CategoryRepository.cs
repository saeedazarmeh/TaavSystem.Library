using Library.DomainLayer.Category;
using Library.DomainLayer.Category.Repository;
using Library.InfraStuctureLayer.Persistent.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.InfraStuctureLayer.Repository
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

        public Category GetById(int categoryId)
        {
           return _dbContext.Categories.FirstOrDefault(c=>c.Id==categoryId);
        }

        public List<Category> GetAll()
        {
            return _dbContext.Categories.ToList();
        }

        public List<Category> GetAllByItsBooks()
        {
            return _dbContext.Categories.Include(c=>c.Books).ToList();
        }

        public void Update(Category category)
        {
            _dbContext.Categories.Update(category);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
