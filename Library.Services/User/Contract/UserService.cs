
using Library.Contract.Exeption;
using Library.Contract.UnitOfWork;
using Library.Entities.User;
using Library.Services.Books.Contract.Repository;
using Library.Services.User.Contract.DTO;
using Library.Services.User.Contract.Mapper;
using Library.Services.User.Contract.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;
        private readonly UnitOfWork _unit;
        public UserService(IUserRepository userRepository, IBookRepository bookRepository, UnitOfWork unit)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepository;
            _unit = unit;
        }
        public async Task AddUser(UserDTO userDTO)
        {
            var user = new Entities.User.User(userDTO.Name);
            _userRepository.Add(user);
            await _unit.Save();

        }

        public async Task UpdateUser(int userId, UpdateUserDTO updateUserDTO)
        {
            var user = await _userRepository.GetByIdAsyn(userId);
            if (user != null)
            {
                user.Edit(updateUserDTO.Name, updateUserDTO.Emai);
                _userRepository.Update(user);
                await _unit.Save();
            }
        }
        public async Task BorrowBook(int userId, int bookId, UserBorrowBookDTO borrowBookDTO)
        {
            var user = await _userRepository.GetByIdWithBorrowedBooksAsyn(userId);
            var userBorrowedbooksCount = user.BorrowBooks.Where(b => b.Status == Entities.User.Enum.BorrowStatus.NotGetBacked).Count();
            var book = await _bookRepository.GetByIdAsync(bookId);
            var RemainingBook = book.BookCount - _userRepository.CalBookRentedNumbers(bookId);
            if (user == null)
            {
                throw new NotFoundExeption("Data Not Found");
            }
            else if (userBorrowedbooksCount == 4 || RemainingBook == 0)
            {
                throw new Exception("you have rented 4 books or remaining book count is zero");
            }
            var borroow = new BorrowBook(borrowBookDTO.Duration, bookId);
            user.BorrowBook(borroow);
            _userRepository.Update(user);
            await _unit.Save();

        }
        public async Task GetBackBook(int userId, int bookId)
        {
            var user = await _userRepository.GetByIdWithBorrowedBooksAsyn(userId);
            if (user == null)
            {
                throw new NotFoundExeption("Data Not Found");
            }
            var borrow = user.BorrowBooks.FirstOrDefault(b => b.BookId == bookId);
            user.GetBackBook(borrow);
            _userRepository.SaveBorrowBookUpdat(borrow);
            await _unit.Save();

        }

        public async Task DeletUser(int userId)
        {
            var user = await _userRepository.GetByIdWithBorrowedBooksAsyn(userId);
            var hasRentedBook = user.BorrowBooks.Any(b => b.Status == Entities.User.Enum.BorrowStatus.NotGetBacked);
            if (user != null && hasRentedBook)
            {
                _userRepository.Delete(user);

                _unit.Save();
            }
            else
            {
                throw new Exception($"This user By Id:{userId} has Book that didn't get Bake");
            }
        }
        public async Task<List<UserResultDTO>> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return users.UsersMap();
        }

        public async Task<List<UserResultDTO>> GetFillteredUsers(UserFillteringDTO user)
        {
            var users = await _userRepository.GetByNameAsyn(user.Name);
            return users.UsersMap();
        }

        public async Task<UserResultDTO> GetUserById(int userId)
        {
            var user = await _userRepository.GetByIdAsyn(userId);
            return user.UserMap();
        }
        public async Task<UserResultDTOWithBooks> GetUserByIdWithBorrrowedBooks(int userId)
        {
            var user = await _userRepository.GetByIdWithBorrowedBooksAsyn(userId);
            return user.UserMapWithBooks();
        }
    }
}
