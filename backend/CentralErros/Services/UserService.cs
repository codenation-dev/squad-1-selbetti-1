using CentralErros.Models;
using Microsoft.EntityFrameworkCore;

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
            var state = user.Id == 0 ? EntityState.Added : EntityState.Modified;
            context.Entry(user).State = state;
            context.SaveChanges();
            return user;
        }
    }
}
