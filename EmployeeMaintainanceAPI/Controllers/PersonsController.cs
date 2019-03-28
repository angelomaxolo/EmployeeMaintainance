using EmployeeMaintainance.Persistance.Repositories.Interface;
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
