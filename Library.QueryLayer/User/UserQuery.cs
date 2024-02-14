using Library.DomainLayer.User.Repository;
using Library.QueryLayer.DTO;
using Library.QueryLayer.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.QueryLayer.User
{
    public interface IUserQuery
    {
        Task<List<UserResultDTO>> GetAllUsers();
        Task<UserResultDTO> GetUserById(int userId);
        Task<List<UserResultDTO>> GetFillteredUsers(UserFillteringDTO user);
        Task<UserResultDTOWithBooks> GetUserByIdWithBorrrowedBooks(int userId);
    }
    public class UserQuery : IUserQuery
    {
        private readonly IUserRepository _repository;

        public UserQuery(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<UserResultDTO>> GetAllUsers()
        {
            var users =await _repository.GetAllAsync();
            return users.UsersMap();
        }

        public async Task<List<UserResultDTO>> GetFillteredUsers(UserFillteringDTO user)
        {
            var users =await _repository.GetByNameAsyn(user.Name);
            return users.UsersMap();
        }

        public async Task<UserResultDTO> GetUserById(int userId)
        {
            var user =await _repository.GetByIdAsyn(userId);
            return user.UserMap();
        }
        public async Task<UserResultDTOWithBooks> GetUserByIdWithBorrrowedBooks(int userId)
        {
            var user =await _repository.GetByIdWithBorrowedBooksAsyn(userId);
            return user.UserMapWithBooks();
        }
    }
}
