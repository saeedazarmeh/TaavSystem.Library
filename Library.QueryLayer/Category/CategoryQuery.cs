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

        List<CategoryResultDTO> GetCategories();
        List<CategoryResultDTOByItsBooks> GetCategoriesByBooks();
        CategoryResultDTO GetCategory(int categoryId);
    }
    public class CategoryQuery:ICategoryQuery
    {
        private readonly ICategoryRepository _repository;

        public CategoryQuery(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public List<CategoryResultDTO> GetCategories()
        {
            var categories=_repository.GetAll();
            return categories.CategoriesMap();
        }
        public List<CategoryResultDTOByItsBooks> GetCategoriesByBooks()
        {
            var categories = _repository.GetAll();
            return categories.CategoriesMapByItsBooks();
        }
        public CategoryResultDTO GetCategory(int categoryId)
        {
            var category = _repository.GetById(categoryId);
            return category.CategoryMap();
        }
    }
}
