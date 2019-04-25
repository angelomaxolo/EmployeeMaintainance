using Employeemaintainance.Models.DTOs.Person;
using Employeemaintainance.Models.Entities;
using EmployeeMaintainance.Persistance.Persistance;
using EmployeeMaintainance.Persistance.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EmployeeMaintainance.Persistance.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly EmployeeContext _context;

        public PersonRepository(EmployeeContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Inserts an entry into the <see cref="Person"/> table.
        /// </summary>
        /// <param name="personDto"></param>
        /// <returns></returns>
        public async Task<Person> CreatePersonAsync(PersonDTO personDto)
        {

            var personToCreate = new Person()
            {
                LastName = personDto.LastName,
                FirstName = personDto.FirstName,
                BirthDate = personDto.DateOfBirth

            };

             _context.Persons.Add(personToCreate);

             await _context.SaveChangesAsync();

             return personToCreate;
        }

        /// <summary>
        /// updated an existing <see cref="Person"/> entry in the  database.
        /// </summary>
        /// <param name="personDto"></param>
        /// <returns></returns>
        public async Task<Person> UpdatePersonAsync(PersonDTO personDto)
        {
            var personToBeUpdated =
                await _context.Persons.FirstOrDefaultAsync(person => person.PersonId == personDto.Id);

            if (personDto == null)
                return null;

            personToBeUpdated.LastName = personDto.LastName;
            personToBeUpdated.FirstName = personDto.FirstName;
            personToBeUpdated.BirthDate = personDto.DateOfBirth;

            await _context.SaveChangesAsync();

            return personToBeUpdated;
        }

        /// <summary>
        /// Removes the specified person from the database.
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>

        public async Task<int> DeletePersonAsync(int personId)
        {
            var personToDelete = await _context.Persons.FirstOrDefaultAsync(person => person.PersonId == personId);

            _context.Remove(personToDelete);

            return await _context.SaveChangesAsync();
        }

       /// <summary>
       /// Retrieves <see cref="Person"/> from the database based on the specified id.
       /// </summary>
       /// <param name="personId"></param>
       /// <returns></returns>
        public async Task<Person> GetPersonAsync(int personId) =>
            await _context.Persons.FirstOrDefaultAsync(person => person.PersonId == personId);
    }
}
    