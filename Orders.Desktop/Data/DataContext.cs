using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Orders.Shared.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Desktop.Data
{
    internal class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DataContext() // For migrations or if you don't use DI everywhere
        {
            // You might need a way to get the configuration here if not using DI
            // For example, if Program.Configuration is static:
            _configuration = Program.Program.Configuration;// Program.Configuration;
        }

        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("LocalConnection3"));
            }
        }

        //// Your DbSets here
        //public DbSet<YourEntity> YourEntities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
    }
}
