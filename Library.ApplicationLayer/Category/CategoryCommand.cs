using Library.ApplicationLayer.Book;
using Library.DomainLayer.Category.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ApplicationLayer.Category
{
    public interface ICategoryCommand
    {
        void AddCategory(CategoryDTO categoryDTO);
        void UpdateCategory(int categoryId, CategoryDTO categoryDTO);
    }

    public class CategoryCommand : ICategoryCommand
    {
        private readonly ICategoryRepository _repository;

        public CategoryCommand(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public void AddCategory(CategoryDTO categoryDTO)
        {
            var book = new DomainLayer.Category.Category(categoryDTO.Name);
            _repository.Add(book);
            _repository.Save();
        }
        public void UpdateCategory(int categoryId, CategoryDTO categoryDTO)
        {
            var category = _repository.GetById(categoryId);
            category.Edit(categoryDTO.Name);
            _repository.Update(category);
            _repository.Save();
        }
    }
}
