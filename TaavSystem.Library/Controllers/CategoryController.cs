using Library.Services.Categories.Contract;
using Library.Services.Categories.Contract.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaavSystem.Library.Utilities.Result;

namespace TaavSystem.Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpPost("Add_Category")]
        public async Task<ApiResult> AddCategory([FromBody] CategoryDTO CategoryDTO)
        {
            await _service.AddCategory(CategoryDTO);
            return new ApiController().CommandResult();

        }

        [HttpGet("Get_All_Categorys")]
        public async Task<ApiResult<List<CategoryResultDTO>>> GetAllCategorys()
        {
            var result =await _service.GetCategories();
            return new ApiController().QueryResult<List<CategoryResultDTO>>(result);

        }

        [HttpGet("Get_All_Categorys_whit _Its_Books")]
        public async Task<ApiResult<List<CategoryResultDTOByItsBooks>>> GetAllCategorysWhithItsBooks()
        {
            var result =await _service.GetCategoriesByBooks();
            return new ApiController().QueryResult<List<CategoryResultDTOByItsBooks>>(result);

        }
        [HttpGet("Get_Category/{CategoryId}")]
        public async Task<ApiResult<CategoryResultDTO>> GetCategory([FromRoute] int CategoryId)
        {
            var result =await _service.GetCategory(CategoryId);
            return new ApiController().QueryResult<CategoryResultDTO>(result);

        }

        [HttpPost("Update_Category/{CategoryId}")]
        public async Task<ApiResult> UpdateCategory([FromRoute] int CategoryId, [FromBody] CategoryDTO CategoryDTO)
        {
            await _service.UpdateCategory(CategoryId, CategoryDTO);
            return new ApiController().CommandResult();

        }
    }
}
