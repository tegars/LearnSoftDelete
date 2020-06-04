using LearnSoftDeleted.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSoftDeleted.EntityFramework
{
    public class DBContext : DbContext
    {
        private IConfiguration _configuration;
        public DBContext(DbContextOptions<DBContext> options, IConfiguration configuration) : base (options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Category> Categories { set; get; }
        public DbSet<Product> Products { set; get; }
    }
}
