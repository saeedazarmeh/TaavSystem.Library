using Library.ApplicationLayer.User;
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
        public void AddUser([FromBody] UserDTO user)
        {
             _command.AddUser(user);
        }

        [HttpGet("Get_All_Users")]
        public List<UserResultDTO> GetAllUsers()
        {
            return _query.GetAllUsers();
        }

        [HttpGet("Get_Filltered_Users")]
        public List<UserResultDTO> GetFillterUsers([FromQuery] UserFillteringDTO user)
        {
            return _query.GetFillteredUsers(user);
        }

        [HttpGet("Get_User_ById/{userId}")]
        public UserResultDTO GetUserById([FromRoute] int userId)
        {
            return _query.GetUserById(userId);
        }
        [HttpGet("Get_User_ById_WithBooks/{userId}")]
        public UserResultDTOWithBooks GetUserByIdWithBooks([FromRoute] int userId)
        {
            return _query.GetUserByIdWithBorrrowedBooks(userId);
        }

        [HttpPatch("Update_User")]
        public void UpdateUser([FromBody] UpdateUserDTO updateUserDTO)
        {
            _command.UpdateUser(updateUserDTO);
        }
        [HttpPost("Borrow_User")]
        public void UserBorrowBook([FromQuery] int userId, int bookId,[FromBody] UserBorrowBookDTO borrowBookDTO)
        {
            _command.BorrowBook(userId,bookId,borrowBookDTO);
        }

        [HttpDelete("Borrow_User")]
        public void UserGetBackBook([FromQuery] int userId, int bookId)
        {
            _command.GetBackBook(userId, bookId);
        }

        [HttpDelete("Delete_User")]
        public void DeleteUser([FromQuery] int userId)
        {
            _command.DeletUser(userId);
        }

    }
}
