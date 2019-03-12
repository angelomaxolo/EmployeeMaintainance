using EmployeeMaintainanceAPI.Core.Models;
using EmployeeMaintainanceAPI.Persistance.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMaintainanceAPI.Persistance
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
            ////Ensures that a database is created
            //Database.EnsureCreated();
            //This will execute migrations
            Database.Migrate();
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Employee> Employees { get; set; }
        
        //This Tells the Db context it is being used to connect to a database 

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("");

        //    base.OnConfiguring(optionsBuilder);
        //}
    }

    
}
