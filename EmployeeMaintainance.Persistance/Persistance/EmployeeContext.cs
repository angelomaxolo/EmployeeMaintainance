using Employeemaintainance.Models.Entities;
using EmployeeMaintainance.Persistance.Persistance.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

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
            if (Database.GetMigrations().Any())
            {
                Database.Migrate();
            }
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }

}
