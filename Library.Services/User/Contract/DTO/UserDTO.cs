using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.User.Contract.DTO
{
    public class UserDTO
    {
        public UserDTO(string name)
        {
            Gaurd(name);
            Name = name;
        }
        public string Name { get; set; }

        public void Gaurd(string name)
        {
            if (name == "")
            {
                throw new InvalidDataException("name couldn't be null");
            }
            else if (name.Length > 80)
            {
                throw new InvalidDataException("Length of Name Should be less than 80 char");
            }
        }
    }
    public class UpdateUserDTO
    {
        public UpdateUserDTO(string name, string emai)
        {
            Gaurd(name, emai);
            Name = name;
            Emai = emai;
        }

        public string Name { get; set; }
        public string Emai { get; set; }
        public void Gaurd(string name, string email)
        {
            if (name == "")
            {
                throw new InvalidDataException("name couldn't be null");
            }
            else if (name.Length > 80)
            {
                throw new InvalidDataException("Length of Name Should be less than 80 char");
            }
            else if (email == "")
            {
                throw new InvalidDataException("email couldn't be null");
            }
            else if (email.Length > 50)
            {
                throw new InvalidDataException("Length of email Should be less than 50 char");
            }
        }
    }
    public class UserBorrowBookDTO
    {
        //public DateTime StartDay { get; set; }
        public int Duration { get; set; }
    }
}
