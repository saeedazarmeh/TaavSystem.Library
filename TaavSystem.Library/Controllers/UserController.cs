
using Library.Services.User.Contract;
using Library.Services.User.Contract.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaavSystem.Library.Utilities.Result;

namespace TaavSystem.Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("Add_User")]
        public async Task<ApiResult> AddUser([FromBody] UserDTO user)
        {
            await _service.AddUser(user);
             return new ApiController().CommandResult();
        }

        [HttpGet("Get_All_Users")]
        public async Task<ApiResult<List<UserResultDTO>>> GetAllUsers()
        {
            var result=await _service.GetAllUsers();
            return new ApiController().QueryResult<List<UserResultDTO>>(result);
        }

        [HttpGet("Get_Filltered_Users")]
        public async Task<ApiResult<List<UserResultDTO>>> GetFillterUsers([FromQuery] UserFillteringDTO user)
        {
            var result = await _service.GetFillteredUsers(user);
            return new ApiController().QueryResult<List<UserResultDTO>>(result);
        }

        [HttpGet("Get_User_ById/{userId}")]
        public async Task<ApiResult<UserResultDTO>> GetUserById([FromRoute] int userId)
        {
            var result = await _service.GetUserById(userId);
            return new ApiController().QueryResult<UserResultDTO>(result);
        }
        [HttpGet("Get_User_ById_WithBooks/{userId}")]
        public async Task<ApiResult<UserResultDTOWithBooks>> GetUserByIdWithBooks([FromRoute] int userId)
        {
            var result = await _service.GetUserByIdWithBorrrowedBooks(userId);
            return new ApiController().QueryResult<UserResultDTOWithBooks>(result);
        }

        [HttpPatch("Update_User/{userId}")]
        public async Task<ApiResult> UpdateUser([FromRoute] int userId,[FromBody] UpdateUserDTO updateUserDTO)
        {
            await _service.UpdateUser(userId,updateUserDTO);
            return new ApiController().CommandResult();
        }
        [HttpPatch("Borrow_User/{userId}")]
        public async Task<ApiResult> UserBorrowBook([FromRoute] int userId, [FromQuery] int bookId,[FromBody] UserBorrowBookDTO borrowBookDTO)
        {
            await _service.BorrowBook(userId,bookId,borrowBookDTO);
            return new ApiController().CommandResult();
        }

        [HttpPatch("GetBack_User/{userId}")]
        public async Task<ApiResult> UserGetBackBook([FromRoute] int userId, [FromQuery] int bookId)
        {
            await _service.GetBackBook(userId, bookId);
            return new ApiController().CommandResult();
        }

        [HttpDelete("Delete_User/{userId}")]
        public async Task<ApiResult> DeleteUser([FromRoute] int userId)
        {
            await _service.DeletUser(userId);
            return new ApiController().CommandResult();
        }

    }
}
