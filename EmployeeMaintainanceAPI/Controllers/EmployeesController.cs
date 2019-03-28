using System.Collections.Generic;
using Employeemaintainance.Models.DTOs.Employee;
using EmployeeMaintainance.Logic.Managers.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Employeemaintainance.Models.DTOs.Person;

namespace EmployeeMaintainanceAPI.Controllers
{
    public class EmployeesController : Controller
    {
        private IEmployeeManager _employeeManager;


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

        [HttpGet("api/employee")]
        public async Task<IActionResult> GetEmployeesAsync()
        {
            var employees = await _employeeManager.GetAllEmployeesAsync();

            if (employees == null)
                return NotFound();


            return Ok(employees);
        }

        [HttpPut("api/employee/{id}")]
        public async Task<IActionResult> UpdateEmployeeAsync(int id,[FromBody]UpdateEmployeeDTO employeeDto)
        {
            if (employeeDto == null)
            {
                return BadRequest();
            }

            var employee = await _employeeManager.UpdateEmployeeAsync(id,employeeDto);

            return Ok(employee);
            
        }
        
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

        [HttpDelete("api/employee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee =  await _employeeManager.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

           await _employeeManager.DeleteEmployeeAsync(id);

           return NoContent();

        }
    }
}

