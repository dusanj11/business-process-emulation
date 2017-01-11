using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HiringCompanyData;

namespace HiringCompanyContract
{
    
    [ServiceContract]
    public interface IHiringCompany
    {
       
        [OperationContract]
        List<Employee> GetAllEmployees();

        [OperationContract]
        List<Employee> GetAllNotSignedInEmployees();

        [OperationContract]
        List<Employee> GetReallyAllEmployees();

        [OperationContract]
        Employee GetEmployee(string username, string password);

        [OperationContract]
        bool AddEmployee(Employee employee);

        [OperationContract]
        bool ChangeEmployeePosition(string username, string position);

        [OperationContract]
        bool UpdateEmployee(Employee employee);

        [OperationContract]
        bool ChangePassword(string username, string oldPassword, string newPassword);

        [OperationContract]
        bool EmployeeLogIn(string username);

        [OperationContract]
        bool EmployeeLogOut(string username);

        [OperationContract]
        bool AddHiringCompany(HiringCompany company);

        [OperationContract]
        HiringCompany GetHiringCompany(int id);

        [OperationContract]
        bool AddProjectDefinition(Project project);

        [OperationContract]
        List<Project> GetProjects();

        [OperationContract]
        bool SendDelayingEmail(string username);

      
    }
}
