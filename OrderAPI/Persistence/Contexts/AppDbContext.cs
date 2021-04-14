using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace OrderAPI.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<Order>().ToTable("Orders");
            builder.Entity<Order>().HasKey(p => p.Id);
            builder.Entity<Order>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Order>().Property(p => p.Product);
            builder.Entity<Order>().Property(p => p.PhoneNumber);

            builder.Entity<Customer>().ToTable("Customers");
            builder.Entity<Customer>().Property(p => p.FirstName);
            builder.Entity<Customer>().Property(p => p.LastName);
            builder.Entity<Customer>().Property(p => p.Age);
            builder.Entity<Customer>().Property(p => p.StreetAddress);
            builder.Entity<Customer>().Property(p => p.City);
            builder.Entity<Customer>().Property(p => p.State);
            builder.Entity<Customer>().Property(p => p.PostalCode);
            builder.Entity<Customer>().HasKey(p => p.PhoneNumber);
            builder.Entity<Customer>().Property(p => p.PhoneNumber).IsRequired();
        }
    }
}
