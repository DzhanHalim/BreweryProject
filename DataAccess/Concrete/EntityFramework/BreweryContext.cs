﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

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
        
    }
}
