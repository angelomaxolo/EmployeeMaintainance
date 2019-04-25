using Employeemaintainance.Models.DTOs.Employee;
using EmployeeMaintainance.Logic.Managers.Interface;
using EmployeeMaintainance.Persistance.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMaintainance.Logic.Managers
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IPersonManager _personManager;

        public EmployeeManager(IEmployeeRepository employeeRepo, IPersonManager personManager)
        {
            _employeeRepo = employeeRepo;
            _personManager = personManager;
        }

        public  async Task<CreateEmployeeDTO> CreateEmployeeAsync(CreateEmployeeDTO employeeDto)
        {
            employeeDto.Person = await _personManager.CreatePersonAsync(employeeDto.Person);

            var entity = await _employeeRepo.CreateEmployeeAsync(employeeDto);

            if (entity == null)
                return employeeDto;

            employeeDto.Id = entity.EmployeeId;

            return employeeDto;
        }

        public async Task<UpdateEmployeeDTO> UpdateEmployeeAsync(int id,UpdateEmployeeDTO employeeDto)
        {
            //  employeeDto.Person = await _personManager.UpdatePersonAsync(employeeDto.Person);

            var entity = await _employeeRepo.UpdateEmployeeAsync(id,employeeDto);

            if (entity == null)
                return employeeDto;

            employeeDto.EmployeeNumber = entity.EmployeeNum;
            employeeDto.EmployedDate = entity.EmployedDate;

            return employeeDto;
        }

        public async Task<bool> DeleteEmployeeAsync(int employeeId)
        {
            var entity = await _employeeRepo.DeleteEmployeeAsync(employeeId);

            if (entity > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<CreateEmployeeDTO> GetEmployeeByIdAsync(int employeeId)
        {
            var entity =  await _employeeRepo.GetEmployeeAsync(employeeId);

            if (entity == null)
                return null;

            return new CreateEmployeeDTO
            {
                Id =  entity.EmployeeId, EmployeeNumber = entity.EmployeeNum, EmployedDate = entity.EmployedDate, TerminatedDate = entity.TerminatedDate
            };
            
        }

        public async Task<List<CreateEmployeeDTO>> GetAllEmployeesAsync()
        {
            var entities = await _employeeRepo.GetEmployeesAsync();

            if (entities == null)
            {
                return null;
            }

            var results = entities.Select(entity => new CreateEmployeeDTO
            {
                Id = entity.EmployeeId, EmployeeNumber = entity.EmployeeNum, EmployedDate = entity.EmployedDate,
                TerminatedDate = entity.TerminatedDate
            }).ToList();

            return new List<CreateEmployeeDTO>(results);
        }

        public async Task<List<CreateEmployeeDTO>> SearchEmployeeAsync(string term)
        {
            var entities = await _employeeRepo.SearchEmployeeAsync(term);

            if (entities == null)
            {
                return null;
            }

            var result = entities.Select(entity => new CreateEmployeeDTO
            {
               Id = entity.EmployeeId, EmployeeNumber = entity.EmployeeNum, EmployedDate = entity.EmployedDate, TerminatedDate = entity.TerminatedDate
            }).ToList();

            return new List<CreateEmployeeDTO>(result);
        }
    }
}
