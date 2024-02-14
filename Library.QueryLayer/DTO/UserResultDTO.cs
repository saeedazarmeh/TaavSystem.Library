using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.QueryLayer.DTO
{
    public class UserResultDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
    }
    public class UserFillteringDTO
    {
        public string Name { get; set; }
    }
    public class UserResultDTOWithBooks
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public List<BorrowBookResultDTO> Books=new List<BorrowBookResultDTO>();
    }
    public class BorrowBookResultDTO
    {
        public int BookId { get; set; }
        public DateTime BoroowDate { get; set; }
        public int Duration { get; set; }
    }
}
