using Library.DomainLayer.User;
using Library.DomainLayer.User.Service;
using Library.InfraStuctureLayer.Persistent.EF;
using Library.Persistant.Persistent.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.InfraStuctureLayer.Service
{
    public class UserService : IUserService
    {
        private readonly EFDbContext _dbContext;

        public UserService(EFDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CalBookRentedNumbers(int bookId)
        {
            return _dbContext.BorrowBooks.Where(b=>b.BookId==bookId && b.Status==DomainLayer.User.Enum.BorrowStatus.NotGetBacked).Count();
        }
    }
}
