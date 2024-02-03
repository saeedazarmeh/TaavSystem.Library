using Library.ApplicationLayer.Category;
using Library.QueryLayer.Category;
using Library.QueryLayer.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaavSystem.Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryCommand _command;
        private readonly ICategoryQuery _query;

        public CategoryController(ICategoryCommand command, ICategoryQuery query)
        {
            _command = command;
            _query = query;
        }

        [HttpPost("Add_Category")]
        public void AddCategory([FromBody] CategoryDTO CategoryDTO)
        {
            _command.AddCategory(CategoryDTO);

        }

        [HttpGet("Get_All_Categorys")]
        public List<CategoryResultDTO> GetAllCategorys()
        {
            var Categorys = _query.GetCategories();
            return Categorys;

        }

        [HttpGet("Get_All_Categorys_whit _Its_Books")]
        public List<CategoryResultDTOByItsBooks> GetAllCategorysWhithItsBooks()
        {
            var Categorys = _query.GetCategoriesByBooks();
            return Categorys;

        }
        [HttpGet("Get_Category/{CategoryId}")]
        public CategoryResultDTO GetCategory([FromRoute] int CategoryId)
        {
            var Categorys = _query.GetCategory(CategoryId);
            return Categorys;

        }

        [HttpPost("Update_Category/{CategoryId}")]
        public void UpdateCategory([FromRoute] int CategoryId, [FromBody] CategoryDTO CategoryDTO)
        {
            _command.UpdateCategory(CategoryId, CategoryDTO);

        }
    }
}
