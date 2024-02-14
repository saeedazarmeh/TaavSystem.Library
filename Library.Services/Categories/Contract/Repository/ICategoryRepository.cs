using Library.Entities.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Categories.Contract.Repository
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        Task<List<Category>> GetAllAsync();
        Task<List<Category>> GetAllByItsBooksAsync();
        Task<Category> GetByIdAsync(int categoryId);
        void Update(Category category);
    }
}
