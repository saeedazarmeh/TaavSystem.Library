using Library.Services.Books.Contract.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Categories.Contract.DTO
{
    public class CategoryResultDTO
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
    public class CategoryResultDTOByItsBooks
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<BookResultDTO> Books { get; set; }
    }
}
