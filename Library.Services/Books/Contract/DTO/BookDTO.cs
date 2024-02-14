using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Books.Contract.DTO
{
    public class BookDTO
    {
        public BookDTO(string publishYear, string name, int bookCount)
        {
            Gaurd(name, publishYear);
            PublishYear = publishYear;
            Name = name;
            this.bookCount = bookCount;
        }

        public string PublishYear { get; set; }
        public string Name { get; set; }
        public int bookCount { get; set; }
        public void Gaurd(string name, string publishYear)
        {
            if (name == "")
            {
                throw new InvalidDataException("name couldn't be null");
            }
            else if (name.Length > 50)
            {
                throw new InvalidDataException("Length of Name Should be less than 50 char");
            }
            else if (int.Parse(publishYear) > 2024 || int.Parse(publishYear) < 1800)
            {
                throw new InvalidDataException("publishYear should be between 2024 And 1800");
            }
        }
    }
    public class UpdateBookDTO
    {
        public UpdateBookDTO(string publishYear, string name)
        {
            Gaurd(name, publishYear);
            PublishYear = publishYear;
            Name = name;
        }

        public string PublishYear { get; set; }
        public string Name { get; set; }
        public void Gaurd(string name, string publishYear)
        {
            if (name == "")
            {
                throw new InvalidDataException("name couldn't be null");
            }
            else if (name.Length > 50)
            {
                throw new InvalidDataException("Length of Name Should be less than 50 char");
            }
            else if (int.Parse(publishYear) > 2024 || int.Parse(publishYear) < 1800)
            {
                throw new InvalidDataException("publishYear should be between 2024 And 1800");
            }
        }
    }
}
