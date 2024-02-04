using Library.DomainLayer.User;
using Library.DomainLayer.User.Repository;
using Library.InfraStuctureLayer.Persistent.EF;
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

        public List<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public User GetById(int userId)
        {
            return _dbContext.Users.FirstOrDefault(u=>u.Id==userId);
        }

        public List<User> GetByName(string name)
        {
            return _dbContext.Users.Where(u => u.Name == name).ToList();
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
            _dbContext.BorrowBooks.Remove(borrowBook);
        }

        public User GetByIdWithBorrowedBooks(int userId)
        {
            return _dbContext.Users.Include(u=>u.BorrowBooks).FirstOrDefault(u => u.Id == userId);
        }
    }
}
