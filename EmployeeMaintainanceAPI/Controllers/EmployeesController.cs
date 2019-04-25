using Employeemaintainance.Models.DTOs.Employee;
using EmployeeMaintainance.Logic.Managers.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeMaintainanceAPI.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeManager _employeeManager;

        public EmployeesController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        /// <summary>
        /// This will provide an employee based on the Id which is being passed
        /// </summary>
        /// <param name="id">Mandatory</param>
        /// <returns></returns>
        [HttpGet("api/employee/{id}")]
        public async Task<IActionResult> GetEmployeeAsync(int id)
        {
            if (id <= 0)
                return BadRequest();

            var employee = await _employeeManager.GetEmployeeByIdAsync(id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        /// <summary>
        /// This will get all the employees on the database
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/employee")]
        public async Task<IActionResult> GetEmployeesAsync()
        {
            var employees = await _employeeManager.GetAllEmployeesAsync();

            if (employees == null)
                return NotFound();


            return Ok(employees);
        }

        /// <summary>
        /// This will update an employee based on Id which is being passed
        /// </summary>
        /// <param name="id">Mandatory</param>
        /// <param name="employeeDto"></param>
        /// <returns></returns>
        [HttpPut("api/employee/{id}")]
        public async Task<IActionResult> UpdateEmployeeAsync(int id, [FromBody] UpdateEmployeeDTO employeeDto)
        {
            if (employeeDto == null)
            {
                return BadRequest();
            }

            var employee = await _employeeManager.UpdateEmployeeAsync(id, employeeDto);

            return Ok(employee);

        }

        /// <summary>
        /// This will create a new employee entry
        /// </summary>
        /// <param name="employeeDto"></param>
        /// <returns></returns>
        [HttpPost("api/employee")]
        public async Task<IActionResult> CreateEmployeeAsync([FromBody] CreateEmployeeDTO employeeDto)
        {
            if (employeeDto == null)
            {
                return BadRequest();
            }

            var employee = await _employeeManager.CreateEmployeeAsync(employeeDto);

            return Ok(employee);
        }

        /// <summary>
        /// This will delete an employee based on the Id being passed
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("api/employee/{id}")]
        public async Task<IActionResult> DeleteEmployeeAsync(int id)
        {
            var employee = await _employeeManager.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            await _employeeManager.DeleteEmployeeAsync(id);

            return NoContent();

        }

        /// <summary>
        /// This will search for an employee on the database based on the employee number passed
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        [HttpGet("api/employee/search/{term}")]
        public async Task<IActionResult> SearchEmployeeAsync(string term)
        {
            var employees = await _employeeManager.SearchEmployeeAsync(term);
            if (employees == null)
            {
                return NotFound();
            }

            return Ok(employees);
        }
    }
}

