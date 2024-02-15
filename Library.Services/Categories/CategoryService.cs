using Library.Contract.CommonServices;
using Library.Contract.Exeption;
using Library.Contract.UnitOfWork;
using Library.Entities.Category;
using Library.Services.Categories.Contract;
using Library.Services.Categories.Contract.DTO;
using Library.Services.Categories.Contract.Mapper;
using Library.Services.Categories.Contract.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Categories
{

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly UnitOfWork _unit;

        public CategoryService(ICategoryRepository repository, UnitOfWork unit)
        {
            _repository = repository;
            _unit = unit;
        }

        public async Task AddCategory(CategoryDTO categoryDTO)
        {
            var book = new Category(categoryDTO.Name.RemoveWhithSapases());
            _repository.Add(book);
            await _unit.Save();
        }
        public async Task UpdateCategory(int categoryId, CategoryDTO categoryDTO)
        {
            var category = await _repository.GetByIdAsync(categoryId);
            if (category == null)
            {
                throw new NotFoundExeption("Data not found");
            }
            category.Edit(categoryDTO.Name);
            _repository.Update(category);
            await _unit.Save();
        }
        public async Task<List<CategoryResultDTO>> GetCategories()
        {
            var categories = await _repository.GetAllAsync();
            return categories.CategoriesMap();
        }
        public async Task<List<CategoryResultDTOByItsBooks>> GetCategoriesByBooks()
        {
            var categories = await _repository.GetAllByItsBooksAsync();
            return categories.CategoriesMapByItsBooks();
        }
        public async Task<CategoryResultDTO> GetCategory(int categoryId)
        {
            var category = await _repository.GetByIdAsync(categoryId);
            if (category == null)
            {
                throw new NotFoundExeption("Data not found");
            }
            return category.CategoryMap();
        }
    }
}
