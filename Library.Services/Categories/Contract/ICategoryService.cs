using Library.Services.Categories.Contract.DTO;

namespace Library.Services.Categories.Contract
{
    public interface ICategoryService
    {
        Task AddCategory(CategoryDTO categoryDTO);
        Task UpdateCategory(int categoryId, CategoryDTO categoryDTO);
        Task<List<CategoryResultDTO>> GetCategories();
        Task<List<CategoryResultDTOByItsBooks>> GetCategoriesByBooks();
        Task<CategoryResultDTO> GetCategory(int categoryId);
    }
}
