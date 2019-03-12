using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EmployeeMaintainanceAPI.Core.Dtos;
using EmployeeMaintainanceAPI.Core.Models;
using EmployeeMaintainanceAPI.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.CodeGeneration;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Update;

namespace EmployeeMaintainanceAPI.Controllers
{
    [Route("api/employees")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;


        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult GetPersonsWithOrWithoutEmployeeInfo(bool includeEmployeesInfo = true)
        {
            var personsEntities = _employeeRepository.GetPersonsWithOrWithoutEmployee(includeEmployeesInfo);

            if (personsEntities == null)
            {
                return NotFound();
            }

            if (includeEmployeesInfo)
            {
                var personsResult = Mapper.Map<IEnumerable<PersonDto>>(personsEntities);

                return Ok(personsResult);
            }

            var personsWithOrWithoutEmployeeInfo = Mapper.Map<PersonWithoutEmployeeDto>(personsEntities);

            return Ok(personsWithOrWithoutEmployeeInfo);
        }

        [HttpGet("{id}")]
        public IActionResult GetPersonWithOrWithoutEmployeeInfo(int id, bool includeEmployeeInfo = true)
        {
            //Get Person with or without Employee Details

            var personEntities = _employeeRepository.GetPersonWithOrWithoutEmployee(id, includeEmployeeInfo);

            if (personEntities == null)
            {
                return NotFound();
            }

            if (includeEmployeeInfo)
            {
                var personResult = Mapper.Map<PersonDto>(personEntities);

                return Ok(personResult);
            }

            var personWithoutEmployeeInfo = Mapper.Map<PersonWithoutEmployeeDto>(personEntities);

            return Ok(personWithoutEmployeeInfo);
        }

        [HttpPost]
        public IActionResult CreatePersonWithEmployeeInfo([FromBody] CreatePersonWithEmployeeInfoDto personDto)
        {
            if (personDto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = Mapper.Map<Person>(personDto);

            _employeeRepository.AddPersonWithEmployeeInfo(person);

            if (!_employeeRepository.Save())
            {
                return StatusCode(500, "A problem occured while handling your request");
            }

            var createdPersonToReturn = Mapper.Map<PersonDto>(person);
            return CreatedAtRoute("GetPersonWithOrWithoutEmployeeInfo", new{personDto.Employee, id = person.PersonId}, createdPersonToReturn);

        }



    }
}

