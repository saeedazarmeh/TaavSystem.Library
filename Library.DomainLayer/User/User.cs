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

        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public DateTime CreationAt { get; set; }=DateTime.Now;
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
