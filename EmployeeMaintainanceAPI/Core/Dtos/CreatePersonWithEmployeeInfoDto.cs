using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeMaintainanceAPI.Core.Models;

namespace EmployeeMaintainanceAPI.Core.Dtos
{
    public class CreatePersonWithEmployeeInfoDto
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Employee> Employee { get; set; }
            = new List<Employee>();
    }
}
