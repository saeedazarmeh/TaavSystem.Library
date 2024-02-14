using Library.Entities.Book;
using Library.Entities.User.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities.User
{
    public class BorrowBook
    {
        public BorrowBook(int durationPerDay, int bookId)
        {
            Start = DateTime.Now;
            DurationPerDay = durationPerDay;
            BookId = bookId;
            Status = BorrowStatus.NotGetBacked;
        }

        public int Id { get; private set; }
        public DateTime Start { get; private set; }
        public BorrowStatus Status { get; private set; }
        public int DurationPerDay { get; private set; }
        public int BookId { get; private set; }
        public Book.Book Book { get; private set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public void GetBackBook()
        {
            Status = BorrowStatus.GetBacked;
        }
    }
}
