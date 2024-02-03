using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DomainLayer.User
{
    public class BorrowBook
    {
        public BorrowBook(DateTime start, int durationPerDay , int bookId)
        {
            Start = start;
            DurationPerDay = durationPerDay;
            BookId = bookId;
        }

        public int Id { get;private set; }
        public DateTime Start { get;private set; }
        public int DurationPerDay { get;private set; }
        public int BookId { get; private set; }
        public Book.Book Book { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; }
    }
}
