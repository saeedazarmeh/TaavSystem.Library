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
        Task<List<Author>> GetAllAsync();
        Task<List<Author>> GetAllByItsBooksAsync();
        Task<Author> GetByIdAsync(int authorId);
        void Update(Author author);
    }
}
