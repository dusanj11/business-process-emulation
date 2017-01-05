using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using HiringCompanyContract;
using HiringCompanyService.Access;
using HiringCompanyContract.Data;

namespace HiringCompanyService
{
    public class HiringCompanyService : IHiringCompany
    {


        public List<Employee> GetAllEmployees()
        {
            Console.WriteLine("GetAllEmployees...");
            return EmployeeDB.Instance.GetEmployees();      
        }

        public Employee GetEmployee(string username, string password)
        {
            Console.WriteLine("GetEmployee...");
            return EmployeeDB.Instance.GetEmployee(username, password);
        }

        public bool AddEmployee(Employee employee)
        {
            Console.WriteLine("AddEmployee...");
            return EmployeeDB.Instance.AddEmployee(employee);
        }

        public bool ChangeEmployeePostition(string username, Employee.PositionEnum position)
        {
            Console.WriteLine("ChangeEmployeePostition...");
            return EmployeeDB.Instance.ChangeEmployeePosition(username, position);

        }

        public bool UpdateEmployee(Employee employee)
        {
            Console.WriteLine("UpdateEmployee...");
            return EmployeeDB.Instance.UpdateEmployee(employee);
        }

        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            Console.WriteLine("ChangePassword...");
            return EmployeeDB.Instance.ChangeEmployeePassword(username, oldPassword, newPassword);
        }

        public bool EmployeeLogIn(string username)
        {
            Console.WriteLine("EmployeeLogIn...");
            return EmployeeDB.Instance.EmployeeLogIn(username);
        }

        public bool EmployeeLogOut(string username)
        {
            Console.WriteLine("EmployeeLogOut...");
            return EmployeeDB.Instance.EmployeeLogOut(username);
        }

        public bool AddHiringCompany(HiringCompany company)
        {
            Console.WriteLine("AddHiringCompany...");
            return HiringCompanyDB.Instance.AddCompany(company);
        }

        public HiringCompany GetHiringCompany(int id)
        {
            Console.WriteLine("GetHiringCompany...");
            return HiringCompanyDB.Instance.GetCompany(id);
        }
    }
}
