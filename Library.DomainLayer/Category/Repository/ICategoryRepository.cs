using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DomainLayer.Category.Repository
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        List<Category> GetAll();
        List<Category> GetAllByItsBooks();
        Category GetById(int categoryId);
        void Update(Category category);
        void Save();
    }
}
