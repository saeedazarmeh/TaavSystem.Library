using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ApplicationLayer.Book
{
    public class BookDTO
    {
        public DateTime PublishYear { get;  set; }
        public string Name { get;  set; }
    }
    public class UpdateBookDTO
    {
        public DateTime PublishYear { get; set; }
        public string Name { get; set; }
    }
}
