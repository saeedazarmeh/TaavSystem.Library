using Library.CommonLayer.Exeption;
using Library.DomainLayer.Author;
using Library.DomainLayer.Category.Repository;
using Library.QueryLayer.DTO;
using Library.QueryLayer.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.QueryLayer.Category
{
    public interface ICategoryQuery
    {

        Task<List<CategoryResultDTO>> GetCategories();
        Task<List<CategoryResultDTOByItsBooks>> GetCategoriesByBooks();
        Task<CategoryResultDTO> GetCategory(int categoryId);
    }
    public class CategoryQuery:ICategoryQuery
    {
        private readonly ICategoryRepository _repository;

        public CategoryQuery(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CategoryResultDTO>> GetCategories()
        {
            var categories=await _repository.GetAllAsync();
            return categories.CategoriesMap();
        }
        public async Task<List<CategoryResultDTOByItsBooks>> GetCategoriesByBooks()
        {
            var categories =await _repository.GetAllByItsBooksAsync();
            return categories.CategoriesMapByItsBooks();
        }
        public async Task<CategoryResultDTO> GetCategory(int categoryId)
        {
            var category =await _repository.GetByIdAsync(categoryId);
            if (category == null)
            {
                throw new NotFoundExeption("Data not found");
            }
            return category.CategoryMap();
        }
    }
}
