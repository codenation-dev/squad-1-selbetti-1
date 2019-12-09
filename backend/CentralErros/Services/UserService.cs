using CentralErros.Models;
using System.Collections.Generic;

namespace CentralErros.Services
{
    public class UserService : IUserService
    {
        private CentralErrosContext context;

        public UserService(CentralErrosContext context)
        {
            this.context = context;
        }

        public User Save(User user)
        {
            throw new System.NotImplementedException();
        }

        public User GetByEmail(string email)
        {
            User user = new User();
            return user;
        }

        public List<User> Listar()
        {
            List<User> lstUser = new List<User>();

            return lstUser;
        
        }
    }
}
