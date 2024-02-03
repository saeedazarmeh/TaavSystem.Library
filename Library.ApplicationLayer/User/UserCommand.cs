using Library.ApplicationLayer.Book;
using Library.DomainLayer.User;
using Library.DomainLayer.User.Repository;
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
        void UpdateUser(UpdateUserDTO updateUserDTO);
        void BorrowBook(int userId, int bookId, UserBorrowBookDTO borrowBookDTO);
        void GetBackBook(int userId, int bookId);
        void DeletUser(int userId);
    }
    public class UserCommand : IUserCommand
    {
        private readonly IUserRepository _repository;
        public UserCommand(IUserRepository repository)
        {
            _repository = repository;
        }
        public void AddUser(UserDTO userDTO)
        {
            var user=new DomainLayer.User.User(userDTO.Name);
            _repository.Add(user);
            _repository.Save();

        }

        public void UpdateUser(UpdateUserDTO updateUserDTO)
        {
            var user=_repository.GetById(updateUserDTO.Id);
            if (user != null)
            {
                user.Edit(updateUserDTO.Name, updateUserDTO.Emai);
                _repository.Update(user);
                _repository.Save();
            }
        }
        public void BorrowBook(int userId, int bookId, BorrowBookDTO borrowBookDTO)
        {
            var user=_repository.GetByIdWithBorrowedBooks(userId);
            if (user != null && user.BorrowBooks.Count<4)
            {
                var borroow = new BorrowBook(borrowBookDTO.StartDay, borrowBookDTO.Duration, bookId);
                user.BorrowBook(borroow);
                _repository.Save();
            }
          
        }
        public void GetBackBook(int userId, int bookId)
        {
            var user = _repository.GetByIdWithBorrowedBooks(userId);
            if (user != null)
            {
                var borroow = user.BorrowBooks.FirstOrDefault(b=>b.BookId==bookId);
                user.GetBackBook(borroow);
                _repository.Save();
            }

        }

        public void DeletUser(int userId)
        {
            var user = _repository.GetById(userId);
            if (user != null)
            {
                _repository.Delete(user);
                _repository.Save();
            }
        }
    }
}
