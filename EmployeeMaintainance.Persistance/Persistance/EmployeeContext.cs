using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Employeemaintainance.Models.Entities;
using EmployeeMaintainance.Persistance.Persistance.EntityConfigurations;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EmployeeMaintainance.Persistance.Persistance
{
    public class EmployeeContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }

        //Contractor that calls a DbContextOptions contractor overload
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
         
            //Ensures that a database is created 
            Database.EnsureCreated();

            //seed database
            this.EnsureSeedDataForContext();

            //This will execute migrations only if there are migrations to be executed.
            //if (Database.GetMigrations().Any())
            //{
            //    Database.Migrate();
            //}
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }

}
