using Data.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    class EstoContext : DbContext
    {

        public DbSet<EstoqueModel> Estoque { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;Password=74269;persistsecurityinfo=True;database=sys", new MySqlServerVersion(new Version()));
        }

    }
}
