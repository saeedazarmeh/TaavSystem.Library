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
