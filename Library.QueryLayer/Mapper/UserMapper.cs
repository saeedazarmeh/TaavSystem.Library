using Library.DomainLayer.User;
using Library.QueryLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.QueryLayer.Mapper
{
    internal static class UserMapper
    {
        public static List<UserResultDTO> UsersMap(this List<DomainLayer.User.User> users)
        {
            var usersResultDTO = new List<UserResultDTO>();
            foreach (var user in users)
            {
                usersResultDTO.Add(new UserResultDTO()
                {
                   Name = user.Name,
                   Email=user.Email
                });
            }
            return usersResultDTO;
        }
        public static UserResultDTO UserMap(this DomainLayer.User.User user)
        {
            var userResultDTO = new UserResultDTO()
            {
                Name = user.Name,
                Email = user.Email
            };
            return userResultDTO;
        }
    }
}
