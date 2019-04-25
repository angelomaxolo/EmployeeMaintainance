using Employeemaintainance.Models.DTOs.Person;
using Employeemaintainance.Models.Entities;
using System.Threading.Tasks;

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
