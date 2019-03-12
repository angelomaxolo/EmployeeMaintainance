using System;
using System.Collections.Generic;

namespace EmployeeMaintainanceAPI.Core.Dtos
{
    public class PersonDto
    {
        public int PersonId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }

        public ICollection<EmployeeDto> Employee { get; set; }
            = new List<EmployeeDto>();
    }
}
