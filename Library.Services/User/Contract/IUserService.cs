using Library.Services.User.Contract.DTO;

namespace Library.Services.User.Contract
{
    public interface IUserService
    {
        Task AddUser(UserDTO userDTO);
        Task UpdateUser(int userId, UpdateUserDTO updateUserDTO);
        Task BorrowBook(int userId, int bookId, UserBorrowBookDTO borrowBookDTO);
        Task GetBackBook(int userId, int bookId);
        Task DeletUser(int userId);
        Task<List<UserResultDTO>> GetAllUsers();
        Task<UserResultDTO> GetUserById(int userId);
        Task<List<UserResultDTO>> GetFillteredUsers(UserFillteringDTO user);
        Task<UserResultDTOWithBooks> GetUserByIdWithBorrrowedBooks(int userId);
    }
}
