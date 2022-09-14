using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Core.Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class BreweryContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //thats my localc DB, if we have a public one then we need to provide the password aswell
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Brewery;Trusted_Connection=true");
        }
        // binding the tables with objects 
        public DbSet<Beer> Beers { get; set; } 
        public DbSet<Wholesaler> WholeSaler { get; set; } 
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Brewery> Brewery { get; set; }
        public DbSet<WholesalerStock> WholesalerStock { get; set; }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    }
}
