using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeMaintainanceAPI.Core.Dtos;
using EmployeeMaintainanceAPI.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMaintainanceAPI.Controllers
{
    [Route("api/persons")]
    public class PersonsController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public PersonsController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
    }
}
