using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.QueryLayer.DTO
{
    public class BookResultDTO
    {
        public DateTime PublishYear { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }
    public class BookFilltringtDTO
    {
        public string? Name { get; set; }=null;
        public string? Category { get; set; }=null ;
    }
}
