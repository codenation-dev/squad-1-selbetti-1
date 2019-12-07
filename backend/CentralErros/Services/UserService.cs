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

        public User Save(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
