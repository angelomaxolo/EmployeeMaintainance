using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeMaintainanceAPI.Core.Models;

namespace EmployeeMaintainanceAPI.Persistance
{
     public static class EmployeeContextExtensions
    {
        public static void EnsureSeedDataForContext(this EmployeeContext context)
        {
            if (context.Persons.Any())
            {
                return;
            }


            //init seed data
            var Persons = new List<Person>()
            {
                new Person()
                {
                    LastName = "Maxolo",
                    FirstName = "Angelo",
                    BirthDate = new DateTime(1960, 8, 27),
                    Employee = new List<Employee>()
                    {
                        new Employee()
                        {

                            EmployeeNum = "212200895",
                            EmployedDate = new DateTime(2018, 4, 9),

                        },
                    }
                    
                    
                },

                new Person()
                {
                    LastName = "Mda",
                    FirstName = "Xhanti",
                    BirthDate = new DateTime(1970, 4, 14),
                    Employee = new List<Employee>()
                    {
                        new Employee()
                        {
                            EmployeeNum = "212200896",
                            EmployedDate = new DateTime(2016, 2, 14)
                        },
                    }
                    
                },
                new Person()
                {
                    LastName = "Mfundisi",
                    FirstName = "Ludwe",
                    BirthDate = new DateTime(1980, 3, 7),
                    Employee = new List<Employee>()
                    {
                        new Employee()
                        {
                            EmployeeNum = "212200897",
                            EmployedDate = new DateTime(2017, 5, 3)
                        },
                    }
                },
            }
            ;


            context.Persons.AddRange(Persons);
            context.SaveChanges();
        } 
    }
}
