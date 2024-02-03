using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.QueryLayer.DTO
{
    public class UserResultDTO
    {
        public string Name { get; set; }
        public string? Email { get; set; }
    }
    public class UserFillteringDTO
    {
        public string Name { get; set; }
    }
    public class UserResultDTOWithBooks
    {
        public string Name { get; set; }
        public string? Email { get; set; }
        public List<BorrowBookResultDTO> Books;
    }
    public class BorrowBookResultDTO
    {
        public int BookId { get; set; }
        public DateTime BoroowDate { get; set; }
        public int Duration { get; set; }
    }
}
