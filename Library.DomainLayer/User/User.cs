using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DomainLayer.User
{
    public class User
    {
        public User(string name)
        {
            Name = name;
        }

        public int Id { get;private set; }
        public string Name { get;private set; }
        public string? Email { get;private set; }
        public DateTime CreationAt { get;private set; }=DateTime.Now;
        public List<BorrowBook> BorrowBooks { get;private set; }=new List<BorrowBook>();
        public void BorrowBook(BorrowBook borrowBook)
        {
            BorrowBooks.Add(borrowBook);
        }
        public void GetBackBook(BorrowBook borrowBook)
        {
            borrowBook.GetBackBook();
        }
        public void Edit(string name, string email)
        {
            if(name != null)
            {
                Name=name;
            }
            if(email != null)
            {
                Email=email;
            }
        }
    }
}
