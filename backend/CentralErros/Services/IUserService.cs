using CentralErros.Models;
using System.Collections.Generic;

namespace CentralErros.Services
{
    public interface IUserService
    {
        User Save(User user);

        User Get(int id);

        List<User> GetAll();
    }
}
