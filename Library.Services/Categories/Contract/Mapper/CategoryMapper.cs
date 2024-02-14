using Library.Entities.Category;
using Library.Services.Books.Contract.Mapper;
using Library.Services.Categories.Contract.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Categories.Contract.Mapper
{
    public static class CategoryMapper
    {
        public static List<CategoryResultDTO> CategoriesMap(this List<Category> categories)
        {
            var categoriesDTO = new List<CategoryResultDTO>();
            foreach (var category in categories)
            {
                categoriesDTO.Add(new CategoryResultDTO()
                {
                    CategoryId = category.Id,
                    Name = category.Name
                });
            }
            return categoriesDTO;
        }
        public static List<CategoryResultDTOByItsBooks> CategoriesMapByItsBooks(this List<Category> categories)
        {
            var categoriesDTO = new List<CategoryResultDTOByItsBooks>();
            foreach (var category in categories)
            {
                categoriesDTO.Add(new CategoryResultDTOByItsBooks()
                {
                    CategoryId = category.Id,
                    Name = category.Name,
                    Books = category.Books.BooksMap()
                });

            }
            return categoriesDTO;
        }
        public static CategoryResultDTO CategoryMap(this Category category)
        {
            return new CategoryResultDTO()
            {
                CategoryId = category.Id,
                Name = category.Name,
            };
        }
    }
}
