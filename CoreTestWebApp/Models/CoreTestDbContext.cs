using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;

namespace CoreTestWebApp.Models
{
    public class CoreTestDbContext : DbContext
    {
        public CoreTestDbContext() : base() { }
        public CoreTestDbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            optionsBuilder.UseSqlServer("Server=SQL;Database=CoreTestDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Customer>().Ignore(c => c.Properties);
            modelBuilder.Entity<Customer>().Property<int>("ZFAPPROVALSTATE").HasColumnName("ZFAPPROVALSTATE").HasColumnType("int");
            modelBuilder.Entity<Customer>().Property<string>("ZFENTRYREASON").HasColumnName("ZFENTRYREASON").HasColumnType("varchar(max)");
        }
    }
}
