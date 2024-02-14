using Library.ApplicationLayer.Book;
using Library.CommonLayer.Exeption;
using Library.CommonLayer.UnitOfWork;
using Library.DomainLayer.Book.Repository;
using Library.DomainLayer.User;
using Library.DomainLayer.User.Repository;
using Library.DomainLayer.User.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ApplicationLayer.User
{
    public interface IUserCommand
    {
        Task AddUser(UserDTO userDTO);
        Task UpdateUser(int userId, UpdateUserDTO updateUserDTO);
        Task BorrowBook(int userId, int bookId, UserBorrowBookDTO borrowBookDTO);
        Task GetBackBook(int userId, int bookId);
        Task DeletUser(int userId);
    }
    public class UserCommand : IUserCommand
    {
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IUserService _userService;
        private readonly UnitOfWork _unit;
        public UserCommand(IUserRepository userRepository,IUserService userService
            ,IBookRepository bookRepository,UnitOfWork unit)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepository;
            _userService = userService;
            _unit = unit;
        }
        public async Task AddUser(UserDTO userDTO)
        {
            var user=new DomainLayer.User.User(userDTO.Name);
            _userRepository.Add(user);
            await _unit.Save();

        }

        public async Task UpdateUser(int userId, UpdateUserDTO updateUserDTO)
        {
            var user=await _userRepository.GetByIdAsyn(userId);
            if (user != null)
            {
                user.Edit(updateUserDTO.Name, updateUserDTO.Emai);
                _userRepository.Update(user);
                await _unit.Save();
            }
        }
        public async Task BorrowBook(int userId, int bookId, UserBorrowBookDTO borrowBookDTO)
        {
            var user=await _userRepository.GetByIdWithBorrowedBooksAsyn(userId);
            var userBorrowedbooksCount= user.BorrowBooks.Where(b => b.Status == DomainLayer.User.Enum.BorrowStatus.NotGetBacked).Count();
            var book=await _bookRepository.GetByIdAsync(bookId);
            var RemainingBook =book.BookCount - _userService.CalBookRentedNumbers(bookId);
            if (user == null )
            {
                throw new NotFoundExeption("Data Not Found");
            }
            else if (userBorrowedbooksCount == 4 || RemainingBook == 0)
            {
                throw new Exception("you have rented 4 books or remaining book count is zero");
            }
            var borroow = new BorrowBook( borrowBookDTO.Duration, bookId);
            user.BorrowBook(borroow);
            _userRepository.Update(user);
            await _unit.Save();

        }
        public async Task GetBackBook(int userId, int bookId)
        {
            var user =await _userRepository.GetByIdWithBorrowedBooksAsyn(userId);
            if (user == null)
            {
                throw new NotFoundExeption("Data Not Found");
            }
                var borrow = user.BorrowBooks.FirstOrDefault(b=>b.BookId==bookId);
                user.GetBackBook(borrow);
                _userRepository.SaveBorrowBookUpdat(borrow);
                await _unit.Save();

        }

        public async Task DeletUser(int userId)
        {
            var user =await _userRepository.GetByIdWithBorrowedBooksAsyn(userId);
            var hasRentedBook = user.BorrowBooks.Any(b=>b.Status==DomainLayer.User.Enum.BorrowStatus.NotGetBacked);
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
    }
}
