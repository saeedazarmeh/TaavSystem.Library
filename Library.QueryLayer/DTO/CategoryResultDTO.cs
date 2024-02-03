using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.QueryLayer.DTO
{
    public class CategoryResultDTO
    {
        public string Name { get; set; }
    }
    public class CategoryResultDTOByItsBooks
    {
        public string Name { get; set; }
        public List<BookResultDTO> Books { get; set; }
    }
}
