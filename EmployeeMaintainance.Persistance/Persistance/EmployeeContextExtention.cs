using Employeemaintainance.Models.Entities;
using EmployeeMaintainance.Persistance.Persistance;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeMaintainance.Persistance
{
    public static class EmployeeContextExtension
    {
        public static void EnsureSeedDataForContext(this EmployeeContext context)

        {
            SeedPeople(context);
            SeedEmployees(context);
        }

        private static void SeedPeople(EmployeeContext context)
        {
            if (context.Persons.Any())
                return;

            //create people 
            var people = new List<Person>
            {
                new Person()
                {
                    LastName = "Maxolo",
                    FirstName = "Angelo",
                    BirthDate = new DateTime(1960, 4, 8)
                },
                new Person()
                {
                    LastName = "Mda",
                    FirstName = "Xhanti",
                    BirthDate = new DateTime(1950, 2, 8)
                }

            };
                
            context.Persons.AddRange(people);
            context.SaveChanges();
        }

        private static void SeedEmployees(EmployeeContext context)
        {
            if (context.Employees.Any())
                return;

            var xhanti = context.Persons.FirstOrDefault(person => person.FirstName.Equals("Xhanti"));

            //create employees
            var employee1 = new Employee
            {
                EmployeeNum = Guid.NewGuid().ToString().Substring(0,16),
                EmployedDate = DateTime.Now,
                PersonalDetails = xhanti
            };

            var angelo = context.Persons.FirstOrDefault(person => person.FirstName.Equals("Angelo"));

            var employee2 = new Employee
            {
                EmployeeNum = Guid.NewGuid().ToString().Substring(0,16),
                EmployedDate = DateTime.Now,
                PersonalDetails = angelo
            };

            context.AddRange(employee1, employee2);
            context.SaveChanges();
        }
    }
}
