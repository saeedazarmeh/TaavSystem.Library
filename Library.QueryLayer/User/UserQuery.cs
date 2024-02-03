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
        List<UserResultDTO> GetAllUsers();
        UserResultDTO GetUserById(int userId);
        List<UserResultDTO> GetFillteredUsers(UserFillteringDTO user);
        UserResultDTOWithBooks GetUserByIdWithBorrrowedBooks(int userId);
    }
    public class UserQuery : IUserQuery
    {
        private readonly IUserRepository _repository;

        public UserQuery(IUserRepository repository)
        {
            _repository = repository;
        }

        public List<UserResultDTO> GetAllUsers()
        {
            var users = _repository.GetAll();
            return users.UsersMap();
        }

        public List<UserResultDTO> GetFillteredUsers(UserFillteringDTO user)
        {
            var users =_repository.GetByName(user.Name);
            return users.UsersMap();
        }

        public UserResultDTO GetUserById(int userId)
        {
            var user = _repository.GetById(userId);
            return user.UserMap();
        }
        public UserResultDTOWithBooks GetUserByIdWithBorrrowedBooks(int userId)
        {
            var user = _repository.GetByIdWithBorrowedBooks(userId);
            return user.UserMapWithBooks();
        }
    }
}
