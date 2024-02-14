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
        Task<List<User>> GetAllAsync();
        Task<List<User>> GetByNameAsyn(string name);
        Task<User> GetByIdAsyn(int userId);
        Task<User> GetByIdWithBorrowedBooksAsyn(int userId);
        void Update(User use);
        void Delete(User user);
        void SaveBorrowBookUpdat(BorrowBook borrowBook);

    }
}
