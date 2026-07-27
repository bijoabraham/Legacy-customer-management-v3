using CustomersWebDemo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;
using System.Web;

namespace CustomersWebDemo.DbAccess
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.Property(g => g.CustomerID).IsRequired().ValueGeneratedOnAdd();
            builder.Property(g => g.CustomerName).IsRequired().HasMaxLength(50);
            builder.Property(g => g.Email).HasMaxLength(100);
            builder.Property(g => g.Location).HasMaxLength(150);
            builder.Property(g => g.Notes).HasMaxLength(1500); 
            builder.Property(g => g.ContractDate); 
            builder.Property(g => g.CustomerType);
            builder.Property(g => g.FlagDeleted); 
           
          
        }
    }
}