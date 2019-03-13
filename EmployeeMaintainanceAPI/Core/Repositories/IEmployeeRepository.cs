using System.Collections.Generic;
using EmployeeMaintainanceAPI.Core.Models;

namespace EmployeeMaintainanceAPI.Core.Repositories
{
    public interface IEmployeeRepository
    {
        Person GetPersonWithEmployeeInfo(int personId);
        IEnumerable<Person> GetPersonsWithEmployeeInfo();
        void AddPersonWithEmployeeInfo(Person person);
        bool Save();

    }
}
