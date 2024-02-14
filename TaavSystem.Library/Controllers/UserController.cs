using Library.ApplicationLayer.User;
using Library.CommonLayer.Result;
using Library.QueryLayer.DTO;
using Library.QueryLayer.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaavSystem.Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserCommand _command;
        private readonly IUserQuery _query;

        public UserController(IUserCommand command, IUserQuery query)
        {
            _command = command;
            _query = query;
        }

        [HttpPost("Add_User")]
        public async Task<ApiResult> AddUser([FromBody] UserDTO user)
        {
            await _command.AddUser(user);
             return new ApiController().CommandResult();
        }

        [HttpGet("Get_All_Users")]
        public async Task<ApiResult<List<UserResultDTO>>> GetAllUsers()
        {
            var result=await _query.GetAllUsers();
            return new ApiController().QueryResult<List<UserResultDTO>>(result);
        }

        [HttpGet("Get_Filltered_Users")]
        public async Task<ApiResult<List<UserResultDTO>>> GetFillterUsers([FromQuery] UserFillteringDTO user)
        {
            var result = await _query.GetFillteredUsers(user);
            return new ApiController().QueryResult<List<UserResultDTO>>(result);
        }

        [HttpGet("Get_User_ById/{userId}")]
        public async Task<ApiResult<UserResultDTO>> GetUserById([FromRoute] int userId)
        {
            var result = await _query.GetUserById(userId);
            return new ApiController().QueryResult<UserResultDTO>(result);
        }
        [HttpGet("Get_User_ById_WithBooks/{userId}")]
        public async Task<ApiResult<UserResultDTOWithBooks>> GetUserByIdWithBooks([FromRoute] int userId)
        {
            var result = await _query.GetUserByIdWithBorrrowedBooks(userId);
            return new ApiController().QueryResult<UserResultDTOWithBooks>(result);
        }

        [HttpPatch("Update_User/{userId}")]
        public async Task<ApiResult> UpdateUser([FromRoute] int userId,[FromBody] UpdateUserDTO updateUserDTO)
        {
            await _command.UpdateUser(userId,updateUserDTO);
            return new ApiController().CommandResult();
        }
        [HttpPatch("Borrow_User/{userId}")]
        public async Task<ApiResult> UserBorrowBook([FromRoute] int userId, [FromQuery] int bookId,[FromBody] UserBorrowBookDTO borrowBookDTO)
        {
            await _command.BorrowBook(userId,bookId,borrowBookDTO);
            return new ApiController().CommandResult();
        }

        [HttpPatch("GetBack_User/{userId}")]
        public async Task<ApiResult> UserGetBackBook([FromRoute] int userId, [FromQuery] int bookId)
        {
            await _command.GetBackBook(userId, bookId);
            return new ApiController().CommandResult();
        }

        [HttpDelete("Delete_User/{userId}")]
        public async Task<ApiResult> DeleteUser([FromRoute] int userId)
        {
            await _command.DeletUser(userId);
            return new ApiController().CommandResult();
        }

    }
}
