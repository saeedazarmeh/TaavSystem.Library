using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ApplicationLayer.Category
{
    public class CategoryDTO
    {
        public CategoryDTO(string name)
        {
            Gaurd(name);
            Name = name;
        }

        public string Name { get;set; }
        public void Gaurd(string name)
        {
            if (name == "")
            {
                throw new InvalidDataException("name couldn't be null");
            }
            else if (name.Length > 30)
            {
                throw new InvalidDataException("Length of Name Should be less than 30 char");
            }
        }
    }
}
