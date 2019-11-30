using System.Collections.Generic;
using CentralErros.Models;

namespace CentralErros.Services
{
    public class UserService : IUserService
    {
        private CentralErrosContext context;

        public UserService(CentralErrosContext context)
        {
            this.context = context;
        }

        public User Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public User Save(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
