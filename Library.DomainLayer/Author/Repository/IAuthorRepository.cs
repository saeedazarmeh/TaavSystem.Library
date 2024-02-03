using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DomainLayer.Author.Repository
{
    public interface IAuthorRepository
    {
        void Add(Author author);
        List<Author> GetAll();
        List<Author> GetAllByItsBooks();
        Author GetById(int authorId);
        void Update(Author author);
        void Save();
    }
}
