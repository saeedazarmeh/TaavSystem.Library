using Library.ApplicationLayer.Category;
using Library.CommonLayer.Result;
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
        public async Task<ApiResult> AddCategory([FromBody] CategoryDTO CategoryDTO)
        {
            await _command.AddCategory(CategoryDTO);
            return new ApiController().CommandResult();

        }

        [HttpGet("Get_All_Categorys")]
        public async Task<ApiResult<List<CategoryResultDTO>>> GetAllCategorys()
        {
            var result =await _query.GetCategories();
            return new ApiController().QueryResult<List<CategoryResultDTO>>(result);

        }

        [HttpGet("Get_All_Categorys_whit _Its_Books")]
        public async Task<ApiResult<List<CategoryResultDTOByItsBooks>>> GetAllCategorysWhithItsBooks()
        {
            var result =await _query.GetCategoriesByBooks();
            return new ApiController().QueryResult<List<CategoryResultDTOByItsBooks>>(result);

        }
        [HttpGet("Get_Category/{CategoryId}")]
        public async Task<ApiResult<CategoryResultDTO>> GetCategory([FromRoute] int CategoryId)
        {
            var result =await _query.GetCategory(CategoryId);
            return new ApiController().QueryResult<CategoryResultDTO>(result);

        }

        [HttpPost("Update_Category/{CategoryId}")]
        public async Task<ApiResult> UpdateCategory([FromRoute] int CategoryId, [FromBody] CategoryDTO CategoryDTO)
        {
            await _command.UpdateCategory(CategoryId, CategoryDTO);
            return new ApiController().CommandResult();

        }
    }
}
