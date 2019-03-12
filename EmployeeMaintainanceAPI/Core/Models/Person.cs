using System;
using System.Collections.Generic;

namespace EmployeeMaintainanceAPI.Core.Models
{
    public class Person
    {
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Employee> Employee { get; set; }
               =new List<Employee>();
        
    }
}
