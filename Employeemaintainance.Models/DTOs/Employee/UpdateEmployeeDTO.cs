using System;
using System.Collections.Generic;
using System.Text;

namespace Employeemaintainance.Models.DTOs.Employee
{
   public class UpdateEmployeeDTO
    {
        public int Id { get; set; }
        public string EmployeeNumber { get; set; }
        public DateTime EmployedDate { get; set; }
        public DateTime? TerminatedDate { get; set; }
    }
}
