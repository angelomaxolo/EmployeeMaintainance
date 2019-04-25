using Employeemaintainance.Models.DTOs.Person;
using System;

namespace Employeemaintainance.Models.DTOs.Employee
{
    public class CreateEmployeeDTO
    {
        public int Id { get; set; }
        public string EmployeeNumber { get; set; }
        public DateTime EmployedDate { get; set; }
        public DateTime? TerminatedDate { get; set; }
        public PersonDTO Person { get; set; }

    }
}
