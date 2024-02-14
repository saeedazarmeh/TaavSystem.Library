using Library.ApplicationLayer.Book;
using Library.CommonLayer.CommonServices;
using Library.CommonLayer.Exeption;
using Library.CommonLayer.Result;
using Library.CommonLayer.UnitOfWork;
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
        Task AddCategory(CategoryDTO categoryDTO);
        Task UpdateCategory(int categoryId, CategoryDTO categoryDTO);
    }

    public class CategoryCommand : ICategoryCommand
    {
        private readonly ICategoryRepository _repository;
        private readonly UnitOfWork _unit;

        public CategoryCommand(ICategoryRepository repository,UnitOfWork unit)
        {
            _repository = repository;
            _unit = unit;   
        }

        public async Task AddCategory(CategoryDTO categoryDTO)
        {
            var book = new DomainLayer.Category.Category(categoryDTO.Name.RemoveWhithSapases());
            _repository.Add(book);
            await _unit.Save();
        }
        public async Task UpdateCategory(int categoryId, CategoryDTO categoryDTO)
        {
            var category =await _repository.GetByIdAsync(categoryId);
            if (category == null)
            {
                throw new NotFoundExeption("Data not found");
            }
            category.Edit(categoryDTO.Name);
            _repository.Update(category);
            await _unit.Save();
        }
    }
}
