using CustomersWebDemo.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CustomersWebDemo.DbAccess
{
    public class CustomerEntitiesDbContext : DbContext
    {
        public CustomerEntitiesDbContext() { }
        public CustomerEntitiesDbContext(DbContextOptions<CustomerEntitiesDbContext> options) : base(options) { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=Customers;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        public DbSet<Customer> Customers { get; set; }
    
        public virtual void Commit()
        {
            this.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        }
    }
}