using Employeemaintainance.Models.DTOs.Employee;
using Employeemaintainance.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeMaintainance.Persistance.Repositories.Interface
{
    public interface IEmployeeRepository
    {
        Task<Employee> CreateEmployeeAsync(CreateEmployeeDTO employeeDto);
        Task<Employee> UpdateEmployeeAsync(int id, UpdateEmployeeDTO employeeDto);
        Task<int> DeleteEmployeeAsync(int employeeId);
        Task<Employee> GetEmployeeAsync(int employeeId);
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<IEnumerable<Employee>> SearchEmployeeAsync(string term);
    }
}
