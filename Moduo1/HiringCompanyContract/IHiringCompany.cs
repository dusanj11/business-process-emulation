using HiringCompanyContract.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HiringCompanyContract
{
    
    [ServiceContract]
    public interface IHiringCompany
    {
       
        [OperationContract]
        List<Data.Employee> GetAllEmployees();

        [OperationContract]
        Data.Employee GetEmployee(string username, string password);

        [OperationContract]
        bool AddEmployee(Data.Employee employee);

        [OperationContract]
        bool ChangeEmployeePostition(string username, Data.Employee.PositionEnum position);

        [OperationContract]
        bool UpdateEmployee(Employee employee);

        [OperationContract]
        bool ChangePassword(string username, string oldPassword, string newPassword);

        [OperationContract]
        bool EmployeeLogIn(string username);

        [OperationContract]
        bool EmployeeLogOut(string username);
    }
}
