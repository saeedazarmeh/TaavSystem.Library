using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DomainLayer.User.Service
{
    public interface IUserService
    {
        int CalBookRentedNumbers(int bookId);
    }
}
