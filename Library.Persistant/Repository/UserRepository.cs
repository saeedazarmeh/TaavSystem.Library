using Library.DomainLayer.User;
using Library.DomainLayer.User.Repository;
using Library.InfraStuctureLayer.Persistent.EF;
using Library.Persistant.Persistent.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.InfraStuctureLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        private EFDbContext _dbContext;
        public UserRepository(EFDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(User user)
        {
           _dbContext.Users.Add(user);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsyn(int userId)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u=>u.Id==userId);
        }

        public async Task<List<User>> GetByNameAsyn(string name)
        {
            return await _dbContext.Users.Where(u => u.Name == name).ToListAsync();
        }

        public void Update(User user)
        {
            
            //_dbContext.Entry(user).State = EntityState.Modified;
            _dbContext.Users.Update(user);
        }

        public void Delete(User user)
        {
            _dbContext.Users.Remove(user);
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public void SaveBorrowBookUpdat(BorrowBook borrowBook)
        {
            _dbContext.BorrowBooks.Update(borrowBook);
        }

        public async Task<User> GetByIdWithBorrowedBooksAsyn(int userId)
        {
            return await _dbContext.Users.Include(u=>u.BorrowBooks).FirstOrDefaultAsync(u => u.Id == userId);
        }
    }
}
