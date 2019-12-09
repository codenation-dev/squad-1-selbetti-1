using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace CentralErros.Models
{
    public class CentralErrosContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }

        public CentralErrosContext(DbContextOptions<CentralErrosContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
<<<<<<< HEAD
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-HFRQTVE;Database=CentralErros;Trusted_Connection=True");
=======
                optionsBuilder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Database=CentralErros;Trusted_Connection=True");
>>>>>>> bbc9b386731dca1d405fb56b77c278a6ed19ac5d
        }
    }
}
