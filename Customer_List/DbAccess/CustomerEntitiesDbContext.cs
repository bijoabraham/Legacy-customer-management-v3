using CustomersWebDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CustomersWebDemo.DbAccess
{
    public class CustomerEntitiesDbContext : DbContext
    {
        public CustomerEntitiesDbContext() : base("CustomersDB") { }

            public DbSet<Customer> Customers { get; set; }
        
            public virtual void Commit()
            {
                base.SaveChanges();
            }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Configurations.Add(new CustomerConfiguration());
                
            }
        
    }
}