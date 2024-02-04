using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DomainLayer.User.Repository
{
    public interface IUserRepository
    {
        void Add(User user);
        List<User> GetAll();
        List<User> GetByName(string name);
        User GetById(int userId);
        User GetByIdWithBorrowedBooks(int userId);
        void Update(User use);
        void Delete(User user);
        void SaveBorrowBookUpdat(BorrowBook borrowBook);
        void Save();
    }
}
