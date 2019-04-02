using System;

namespace Employeemaintainance.Models.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeNum { get; set; }
        public DateTime EmployedDate { get; set; }
        public DateTime? TerminatedDate { get; set; }
        public Person PersonalDetails { get; set; }
    }
}
