using LearnSoftDeleted.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LearnSoftDeleted.EntityFramework
{
    public class DBContext : DbContext
    {
        private IConfiguration _configuration;
        public DBContext(DbContextOptions<DBContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
            //optionsBuilder.UseNpgsql("server=localhost;database=LearnSoftDelete;Port=5432;User Id=postgres;Password=fads;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        private void OnBeforeSaving()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["IsDeleted"] = false;
                        if (entry.Metadata.FindProperty("CreatedAt") != null)
                            entry.CurrentValues["CreatedAt"] = DateTime.Now;
                        if (entry.Metadata.FindProperty("UpdatedAt") != null)
                            entry.CurrentValues["UpdatedAt"] = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        if (entry.Metadata.FindProperty("UpdatedAt") != null)
                            entry.CurrentValues["UpdatedAt"] = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.CurrentValues["IsDeleted"] = true;
                        break;
                }
            }
        }


        public DbSet<Category> Categories { set; get; }
        public DbSet<Product> Products { set; get; }
    }
}
