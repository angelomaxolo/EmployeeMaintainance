using System;

namespace EmployeeMaintainanceAPI.Core.Dtos
{
    public class PersonWithoutEmployeeDto
    {
        public int PersonId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
