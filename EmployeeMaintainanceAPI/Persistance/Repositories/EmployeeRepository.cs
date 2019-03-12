using System.Collections.Generic;
using System.Linq;
using EmployeeMaintainanceAPI.Core.Models;
using EmployeeMaintainanceAPI.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMaintainanceAPI.Persistance.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }

        public Person GetPersonWithOrWithoutEmployee(int personId, bool includeEmployeeInfo)
        {
            if (includeEmployeeInfo)
            {
                return _context.Persons
                    .Include(e => e.Employee).FirstOrDefault(p => p.PersonId == personId);
            }

            return _context.Persons.FirstOrDefault(p => p.PersonId == personId);
        }


        public IEnumerable<Person> GetPersonsWithOrWithoutEmployee(bool includeEmployeeInfo)
        {
            if (includeEmployeeInfo)
            {
                return _context.Persons
                    .Include(e => e.Employee).ToList();
            }

            return _context.Persons.ToList();
        }

        public void AddPersonWithEmployeeInfo(Person person)
        {

            _context.Persons.Add(person);
        

        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}


//This is the place were we apply persistence logic