using System.Collections.Generic;
using Employeemaintainance.Models.DTOs.Employee;
using System.Threading.Tasks;

namespace EmployeeMaintainance.Logic.Managers.Interface
{
    public interface IEmployeeManager
    {
        Task<CreateEmployeeDTO> CreateEmployeeAsync(CreateEmployeeDTO employeeDto);
        Task<UpdateEmployeeDTO> UpdateEmployeeAsync(int id, UpdateEmployeeDTO employeeDto);
        Task<bool> DeleteEmployeeAsync(int employeeId);
        Task<CreateEmployeeDTO> GetEmployeeByIdAsync(int employeeId);
        Task<List<CreateEmployeeDTO>> GetAllEmployeesAsync();
    }
}
