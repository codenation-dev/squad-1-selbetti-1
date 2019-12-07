using CentralErros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralErros.Services
{
    interface ILogService
    {
        Log Save(Log log);

        Log Get(int id);

        List<Log> getAll();

        List<Log> findAllByUserId(int userId);
    }
}
