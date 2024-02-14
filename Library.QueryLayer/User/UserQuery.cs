using Library.DomainLayer.User.Repository;
using Library.QueryLayer.DTO;
using Library.QueryLayer.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.QueryLayer.User
{
    public interface IUserQuery
    {
      
    }
    public class UserQuery : IUserQuery
    {
        private readonly IUserRepository _repository;

        public UserQuery(IUserRepository repository)
        {
            _repository = repository;
        }

       
    }
}
