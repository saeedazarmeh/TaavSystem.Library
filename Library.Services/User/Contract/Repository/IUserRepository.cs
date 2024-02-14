using Library.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.User.Contract.Repository
{
    public interface IUserRepository
    {
        void Add(Entities.User.User user);
        Task<List<Entities.User.User>> GetAllAsync();
        Task<List<Entities.User.User>> GetByNameAsyn(string name);
        Task<Entities.User.User> GetByIdAsyn(int userId);
        Task<Entities.User.User> GetByIdWithBorrowedBooksAsyn(int userId);
        void Update(Entities.User.User use);
        void Delete(Entities.User.User user);
        void SaveBorrowBookUpdat(BorrowBook borrowBook);
        int CalBookRentedNumbers(int bookId);

    }
}
