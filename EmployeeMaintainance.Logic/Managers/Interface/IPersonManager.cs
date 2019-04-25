using Employeemaintainance.Models.DTOs.Person;
using System.Threading.Tasks;

namespace EmployeeMaintainance.Logic.Managers.Interface
{
    public interface IPersonManager
    {
        Task<PersonDTO> CreatePersonAsync(PersonDTO person);
        Task<PersonDTO> UpdatePersonAsync(PersonDTO personDto);
        Task<int> DeletePersonAsync(int personId);
        Task<PersonDTO> GetPersonByIdAsync(int personId);
    }
}
