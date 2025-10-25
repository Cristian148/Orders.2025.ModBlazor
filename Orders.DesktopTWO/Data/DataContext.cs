using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Orders.Shared.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.DesktopTWO.Data
{
    public class DataContext:DbContext
    {
        private readonly IConfiguration _configuration;

        //public DataContext(DbContextOptions<DataContext> options ):base(options)
        //{

        //}

        public DataContext() // For migrations or if you don't use DI everywhere
        {
            // You might need a way to get the configuration here if not using DI
            // For example, if Program.Configuration is static:
            _configuration = Program.Configuration;// Program.Configuration;
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
        public DbSet<Category> Categories { get; set; }
    }
}
