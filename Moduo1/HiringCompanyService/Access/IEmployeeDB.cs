using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiringCompanyContract.Data;

namespace HiringCompanyService.Access
{
    public interface IEmployeeDB
    {
        bool AddEmployee(Employee action);

        List<Employee> GetEmployees();

        Employee GetEmployee(string username, string password);

        bool ChangeEmployeePosition(string username, Employee.PositionEnum position);
    }
}
