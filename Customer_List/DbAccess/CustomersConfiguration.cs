using CustomersWebDemo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CustomersWebDemo.DbAccess
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            ToTable("Customers");
            Property(g => g.CustomerID).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(g => g.CustomerName).IsRequired().HasMaxLength(50);
            Property(g => g.Email).HasMaxLength(100);
            Property(g => g.Location).HasMaxLength(150);
            Property(g => g.Notes).HasMaxLength(1500); 
            Property(g => g.ContractDate); 
            Property(g => g.CustomerType);
            Property(g => g.FlagDeleted); 
           
          
        }
    }
}