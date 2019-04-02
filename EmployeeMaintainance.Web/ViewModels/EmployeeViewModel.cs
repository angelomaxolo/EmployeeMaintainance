using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeMaintainance.Web.ViewModels
{
    public class EmployeeViewModel
    {
        [Required]
        public string EmployeeNumber { get; set; }
        [Required]
        public DateTime EmployedDate { get; set; }
        public DateTime? TerminatedDate { get; set; }
        public PersonFormViewModel PersonalDetails { get; set; }
    }
}
