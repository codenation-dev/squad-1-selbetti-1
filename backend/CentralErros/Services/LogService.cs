using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentralErros.Models;
using Microsoft.EntityFrameworkCore;

namespace CentralErros.Services
{
    public class LogService : ILogService
    {
        private CentralErrosContext _context;

        public LogService(CentralErrosContext context) {
            _context = context;
        }

        public List<Log> findAllByUserId(int userId)
        {
            return _context.Users.Where(el => el.Id == userId).SelectMany(el => el.Logs).ToList();
        }

        public Log Get(int id)
        {
            return _context.Logs.Where(el => el.Id == id).FirstOrDefault();
        }

        public List<Log> getAll()
        {
            return _context.Logs.ToList();
        }

        public Log Save(Log log)
        {
            var state = log.Id == 0 ? EntityState.Added : EntityState.Modified;
            _context.Entry(log).State = state;
            _context.SaveChanges();

            return log;
        }
    }
}
