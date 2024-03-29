﻿using Employeemaintainance.Models.DTOs.Employee;
using Employeemaintainance.Models.Entities;
using EmployeeMaintainance.Persistance.Persistance;
using EmployeeMaintainance.Persistance.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMaintainance.Persistance.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Inserts an entry into the <see cref="Employee"/> table.
        /// </summary>
        /// <param name="employeeDto"></param>
        /// <returns></returns>
        public async Task<Employee> CreateEmployeeAsync(CreateEmployeeDTO employeeDto)
        {
            var employeeToAdd = new Employee
            {
                EmployedDate = employeeDto.EmployedDate,
                EmployeeNum = employeeDto.EmployeeNumber,
                TerminatedDate = employeeDto.TerminatedDate,
                PersonalDetails = new Person
                {
                    PersonId = employeeDto.Person.Id,
                    BirthDate = employeeDto.Person.DateOfBirth,
                    LastName = employeeDto.Person.LastName,
                    FirstName = employeeDto.Person.FirstName
                }
            };

            _context.Employees.Add(employeeToAdd);

            await _context.SaveChangesAsync();

            return employeeToAdd;
        }

        /// <summary>
        /// Updates an existing <see cref="Employee"/> entry in the database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employeeDto"></param>
        /// <returns></returns>
        public async Task<Employee> UpdateEmployeeAsync(int id, UpdateEmployeeDTO employeeDto)
        {
           var employeeToBeUpdated = await _context.Employees.FirstOrDefaultAsync(employee => employee.EmployeeId == id);

           if (employeeToBeUpdated == null)
               return null;

           employeeToBeUpdated.EmployeeNum = employeeDto.EmployeeNumber;
           employeeToBeUpdated.EmployedDate = employeeDto.EmployedDate;
           employeeToBeUpdated.TerminatedDate = employeeDto.TerminatedDate;

           await _context.SaveChangesAsync();

           return employeeToBeUpdated;
        }

        /// <summary>
        /// Removes the specified employee from the database.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task<int> DeleteEmployeeAsync(int employeeId)
        {
            var employeeToDelete =
                await _context.Employees.FirstOrDefaultAsync(employee => employee.EmployeeId == employeeId);

            _context.Employees.Remove(employeeToDelete);

            return await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Retrieves <see cref="Employee"/> from the database based on the specified id.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task<Employee> GetEmployeeAsync(int employeeId) =>
           await _context.Employees.FirstOrDefaultAsync(employee => employee.EmployeeId == employeeId);
        /// <summary>
        /// Retrieves <see cref="Employee"/> from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Employee>> GetEmployeesAsync() =>
            await _context.Employees.ToListAsync();
        /// <summary>
        /// Searches for an <see cref="Employee"/> via employee number
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Employee>> SearchEmployeeAsync(string term) =>
           await _context.Employees.Where(e => e.EmployeeNum.Contains(term)).ToListAsync();
    }
}
