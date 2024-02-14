using Library.ApplicationLayer.Book;
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
        void AddUser(UserDTO userDTO);
        void UpdateUser(int userId, UpdateUserDTO updateUserDTO);
        Task BorrowBook(int userId, int bookId, UserBorrowBookDTO borrowBookDTO);
        void GetBackBook(int userId, int bookId);
        void DeletUser(int userId);
    }
    public class UserCommand : IUserCommand
    {
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IUserService _userService;
        public UserCommand(IUserRepository userRepository,IUserService userService,IBookRepository bookRepository)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepository;
            _userService = userService;
        }
        public void AddUser(UserDTO userDTO)
        {
            var user=new DomainLayer.User.User(userDTO.Name);
            _userRepository.Add(user);
            _userRepository.Save();

        }

        public void UpdateUser(int userId, UpdateUserDTO updateUserDTO)
        {
            var user=_userRepository.GetById(userId);
            if (user != null)
            {
                user.Edit(updateUserDTO.Name, updateUserDTO.Emai);
                _userRepository.Update(user);
                _userRepository.Save();
            }
        }
        public async Task BorrowBook(int userId, int bookId, UserBorrowBookDTO borrowBookDTO)
        {
            var user=_userRepository.GetByIdWithBorrowedBooks(userId);
            var userBorrowedbooksCount= user.BorrowBooks.Where(b => b.Status == DomainLayer.User.Enum.BorrowStatus.NotGetBacked).Count();
            var book=await _bookRepository.GetByIdAsync(bookId);
            var RemainingBook =book.BookCount - _userService.CalBookRentedNumbers(bookId);
            if (user != null && userBorrowedbooksCount < 4 && RemainingBook>0)
            {
                var borroow = new BorrowBook(borrowBookDTO.StartDay, borrowBookDTO.Duration, bookId);
                user.BorrowBook(borroow);
                _userRepository.Update(user);
                 _userRepository.Save();
            }
          
        }
        public void GetBackBook(int userId, int bookId)
        {
            var user = _userRepository.GetByIdWithBorrowedBooks(userId);
            if (user != null)
            {
                var borrow = user.BorrowBooks.FirstOrDefault(b=>b.BookId==bookId);
                user.GetBackBook(borrow);
                _userRepository.SaveBorrowBookUpdat(borrow);
                _userRepository.Save();
            }

        }

        public void DeletUser(int userId)
        {
            var user = _userRepository.GetByIdWithBorrowedBooks(userId);
            var hasRentedBook = user.BorrowBooks.Any(b=>b.Status==DomainLayer.User.Enum.BorrowStatus.NotGetBacked);
            if (user != null && hasRentedBook)
            {
                _userRepository.Delete(user);

                _userRepository.Save();
            }
            else
            {
                throw new Exception($"This user By Id:{userId} has Book that didn't get Bake");
            }
        }
    }
}
