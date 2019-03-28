using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Employeemaintainance.Models.DTOs.Employee;
using Employeemaintainance.Models.DTOs.Person;
using Employeemaintainance.Models.Entities;

namespace EmployeeMaintainance.Persistance.Repositories.Interface
{
    public interface IPersonRepository
    {
        Task<Person> CreatePersonAsync(PersonDTO person);
        Task<Person> UpdatePersonAsync(PersonDTO person);
        Task<int> DeletePersonAsync(int employeeId);
        Task<Person> GetPersonAsync(int employeeId);
    }
}
