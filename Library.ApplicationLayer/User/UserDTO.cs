using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ApplicationLayer.User
{
    public class UserDTO
    {
        public string Name { get; set; }
    }
    public class UpdateUserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Emai { get; set; }
    }
    public class UserBorrowBookDTO
    {
        public DateTime StartDay { get; set; }
        public int Duration { get; set; }
    }
}
