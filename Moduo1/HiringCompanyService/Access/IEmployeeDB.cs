using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiringCompanyData;

namespace HiringCompanyService.Access
{
    public interface IEmployeeDB
    {
        bool AddEmployee(Employee action);

        List<Employee> GetEmployees();

        List<Employee> GetReallyEmployees();

        List<Employee> GetAllNotSignedInEmployees();

        Employee GetEmployee(string username, string password);

        bool ChangeEmployeePosition(string username, string position);

        bool ChangeEmployeePassword(string username, string oldPassword, string newPassword);

        bool UpdateEmployee(Employee employee);

        bool EmployeeLogIn(string username);

        bool EmployeeLogOut(string username);

        String GetEmployeeEmail(string username);

        int GetHcIdForUser(string username);

    }
}
