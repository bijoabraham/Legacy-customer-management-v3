using CustomersWebDemo.DbAccess;
using CustomersWebDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace CustomersWebDemo.DbAccess
{
    public class CustomerDatabaseInitializer : DropCreateDatabaseAlways<CustomerEntitiesDbContext>
    {
        protected override void Seed(CustomerEntitiesDbContext context)
        {
            IList<Customer> seedCustomers = new List<Customer>();
            seedCustomers.Add(new Customer() { CustomerName = "Peter", Email = "peter@peter.com", Location = "Tokio"});
            seedCustomers.Add(new Customer() { CustomerName = "Josephine Darakjy"	,Location ="Brighton	" , Email="josephine@darakjy.org	 "});
            seedCustomers.Add(new Customer() { CustomerName = "Art	Venere"			,Location ="Bridgeport	" , Email="art@venere.org	         "});
            seedCustomers.Add(new Customer() { CustomerName = "Lenna Paprocki", Location = "Anchorage	", Email = "lpaprocki@hotmail.com	 ", CustomerType = CustomerTypeEnum.Person});
            seedCustomers.Add(new Customer() { CustomerName = "Donette	Foller", Location = "Hamilton	", Email = "donette.foller@cox.net	 ", CustomerType = CustomerTypeEnum.Person });
            seedCustomers.Add(new Customer() { CustomerName = "Simona	Morasca", Location = "Ashland	  	", Email = "simona@morasca.com	     ", CustomerType = CustomerTypeEnum.Person });
            seedCustomers.Add(new Customer() { CustomerName = "Mitsue	Tollner", Location = "Chicago		", Email = "mitsue_tollner@yahoo.com	 ", CustomerType = CustomerTypeEnum.Person });
            seedCustomers.Add(new Customer() { CustomerName = "Leota	Dilliard", Location = "San Jose	", Email = "leota@hotmail.com	     ", CustomerType = CustomerTypeEnum.Person });
            seedCustomers.Add(new Customer() { CustomerName = "Sage Wieser", Location = "Sioux Falls	", Email = "sage_wieser@cox.net	     ", CustomerType = CustomerTypeEnum.Person });
            seedCustomers.Add(new Customer() { CustomerName = "Kris Marrier", Location = "Baltimore	", Email = "kris@gmail.com	         ", CustomerType = CustomerTypeEnum.Person });
            seedCustomers.Add(new Customer() { CustomerName = "Minna	Amigon", Location = "Kulpsville	", Email = "minna_amigon@yahoo.com	 ", CustomerType = CustomerTypeEnum.Person });
            seedCustomers.Add(new Customer() { CustomerName = "Kiley	Caldarera", Location = "Los Angeles	", Email = "kiley.caldarera@aol.com	 ", CustomerType = CustomerTypeEnum.Person });
            seedCustomers.Add(new Customer() { CustomerName = "Mattie	Poquette", Location = "Phoenix		", Email = "mattie@aol.com	         ", CustomerType = CustomerTypeEnum.Person });
            seedCustomers.Add(new Customer() { CustomerName = "Fletcher Flosi", Location = "Rockford	", Email = "fletcher.flosi@yahoo.com	 ", CustomerType = CustomerTypeEnum.Person });
            seedCustomers.Add(new Customer() { CustomerName = "Bette	Nicka", Location = "Aston		", Email = "bette_nicka@cox.net	     ", CustomerType = CustomerTypeEnum.Person });
            seedCustomers.Add(new Customer() { CustomerName = "Veronika	Inouye"		,Location ="San Jose	" , Email="vinouye@aol.com	         ", CustomerType = CustomerTypeEnum.Corporation});
            seedCustomers.Add(new Customer() { CustomerName = "Willard	Kolmetz", Location = "Irving		", Email = "willard@hotmail.com	     ", CustomerType = CustomerTypeEnum.Corporation });
            seedCustomers.Add(new Customer() { CustomerName = "Maryann	Royster", Location = "Albany		", Email = "mroyster@royster.com      ", CustomerType = CustomerTypeEnum.Corporation });
            seedCustomers.Add(new Customer() { CustomerName = "Alisha	Slusarski", Location = "Middlesex	", Email = "alisha@slusarski.com      ", CustomerType = CustomerTypeEnum.Corporation });
            seedCustomers.Add(new Customer() { CustomerName = "Willow	Kusko", Location = "New York	", Email = "wkusko@yahoo.com	         ", CustomerType = CustomerTypeEnum.Person });
            seedCustomers.Add(new Customer() { CustomerName = "Lavera	Perin", Location = "Miami		", Email = "lperin@perin.org	         ", CustomerType = CustomerTypeEnum.Person });
            seedCustomers.Add(new Customer() { CustomerName = "Jina	Briddick", Location = "Boston		", Email = "jina_briddick@briddick.com", CustomerType = CustomerTypeEnum.Person });	



            foreach (Customer c in seedCustomers)
                context.Customers.Add(c);

            base.Seed(context);
        }
    }
}