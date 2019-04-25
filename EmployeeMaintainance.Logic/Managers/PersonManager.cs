using Employeemaintainance.Models.DTOs.Person;
using EmployeeMaintainance.Logic.Managers.Interface;
using EmployeeMaintainance.Persistance.Repositories.Interface;
using System.Threading.Tasks;

namespace EmployeeMaintainance.Logic.Managers
{
    public class PersonManager : IPersonManager

    {
        private readonly IPersonRepository _personRepo;

        public PersonManager(IPersonRepository personRepo)
        {
            _personRepo = personRepo;
        }

        public async Task<PersonDTO> CreatePersonAsync(PersonDTO person)
        {
           var entity = await _personRepo.CreatePersonAsync(person);

           if (entity == null)
               return person;

           person.Id = entity.PersonId;

           return person;
        }

        public async Task<PersonDTO> UpdatePersonAsync(PersonDTO personDto)
        {
            var entity = await _personRepo.UpdatePersonAsync(personDto);

            if (entity == null)
                return personDto;

            personDto.Id = entity.PersonId;
            personDto.FirstName = entity.FirstName;
            personDto.LastName = entity.LastName;
            personDto.DateOfBirth = entity.BirthDate;

            return personDto;
        }

        public async Task<int> DeletePersonAsync(int personId)
        {
            return await _personRepo.DeletePersonAsync(personId);
        }
        
        public async Task<PersonDTO> GetPersonByIdAsync(int personId)
        {
            var entity = await _personRepo.GetPersonAsync(personId);

            if (entity == null)
                return null;

            return new PersonDTO
            {
                Id = entity.PersonId, FirstName = entity.FirstName, LastName = entity.LastName,
                DateOfBirth = entity.BirthDate
            };
        }
    }
}
