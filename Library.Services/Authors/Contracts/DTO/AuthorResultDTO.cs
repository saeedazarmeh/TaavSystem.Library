﻿using Library.Services.Books.Contract.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Authors.Contracts.DTO
{
    public class AuthorResultDTO
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
    }
    public class AuthorResultDTOByItsBooks
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public List<BookResultDTO> Books { get; set; }
    }
}