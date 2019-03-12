using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeMaintainanceAPI.Core.Models
{
    public class Employee
    {
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        [ForeignKey("PersonId")]
        public Person Person { get; set; }
        public int PersonId { get; set; }
        public string EmployeeNum { get; set; }
        public DateTime EmployedDate { get; set; }
        public DateTime TerminatedDate { get; set; }


    }
}
