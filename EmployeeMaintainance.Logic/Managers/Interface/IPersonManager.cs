using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Employeemaintainance.Models.DTOs.Person;
using Employeemaintainance.Models.Entities;

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
