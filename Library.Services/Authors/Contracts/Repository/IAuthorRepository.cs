using Library.Entities.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Authors.Contracts.Repository
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
