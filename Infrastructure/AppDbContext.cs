using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Infrastructure
{
    public class AppDbContext:DbContext
    {
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Clientes> clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source = SRVMIO;" +
                    "initial catalog=ProCliDB; User Id=usMio; Pwd=Rcm123456;" +
                    "TrustServerCertificate=true");
        }
    }
}
