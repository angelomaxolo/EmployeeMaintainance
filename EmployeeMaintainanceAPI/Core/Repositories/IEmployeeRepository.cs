using System.Collections.Generic;
using EmployeeMaintainanceAPI.Core.Models;

namespace EmployeeMaintainanceAPI.Core.Repositories
{
    public interface IEmployeeRepository
    {
        Person GetPersonWithOrWithoutEmployee(int personId, bool includeEmployeeInfo);
        IEnumerable<Person> GetPersonsWithOrWithoutEmployee(bool includeEmployeeInfo);
        void AddPersonWithEmployeeInfo(Person person);
        bool Save();

    }
}
