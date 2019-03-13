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
        public IActionResult GetPersonsWithEmployeeInfo()
        {
            var personsEntities = _employeeRepository.GetPersonsWithEmployeeInfo();

            if (personsEntities == null)
            {
                return NotFound();
            }

            var personsResult = Mapper.Map<IEnumerable<PersonDto>>(personsEntities);

            return Ok(personsResult);
;
        }

        [HttpGet("{id}", Name = "GetPersonWithEmployeeInfo")]
        
        public IActionResult GetPersonWithEmployeeInfo(int pId)
        {
            
            //Get Person with or without Employee Details

            var personEntities = _employeeRepository.GetPersonWithEmployeeInfo(pId);

            if (personEntities == null)
            {
                return NotFound();
            }

            var personResult = Mapper.Map<PersonDto>(personEntities);

            return Ok(personResult);
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

            return CreatedAtRoute("GetPersonWithEmployeeInfo", new
                {id = person.PersonId}, createdPersonToReturn);

        }



    }
}

