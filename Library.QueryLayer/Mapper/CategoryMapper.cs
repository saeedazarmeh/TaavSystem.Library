using Library.QueryLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.QueryLayer.Mapper
{
    public static class CategoryMapper
    {
        public static List<CategoryResultDTO> CategoriesMap(this List<DomainLayer.Category.Category> categories)
        {
            var categoriesDTO = new List<CategoryResultDTO>();
            foreach (var category in categories)
            {
                categoriesDTO.Add(new CategoryResultDTO() { Name = category.Name });
            }
            return categoriesDTO;
        }
        public static List<CategoryResultDTOByItsBooks> CategoriesMapByItsBooks(this List<DomainLayer.Category.Category> categories)
        {
            var categoriesDTO = new List<CategoryResultDTOByItsBooks>();
            foreach (var category in categories)
            {
                categoriesDTO.Add(new CategoryResultDTOByItsBooks()
                {
                    Name = category.Name,
                    Books = category.Books.BooksMap()
                });

            }
            return categoriesDTO;
        }
        public static CategoryResultDTO CategoryMap(this DomainLayer.Category.Category category)
        {
            return new CategoryResultDTO()
                {
                    Name = category.Name,
                };
        }
    }
}
