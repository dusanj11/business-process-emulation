using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiringCompanyContract;
using System.ServiceModel;
using HiringCompanyContract.Data;

namespace Client
{
    public class ClientProxy : ChannelFactory<IHiringCompany>, IHiringCompany, IDisposable
    {
        private IHiringCompany factory; 

        public ClientProxy(NetTcpBinding binding, string address) : base(binding, address)
        {
            factory = this.CreateChannel();
        }

        public void Dispose()
        {
            if (factory != null)
            {
                factory = null;

            }
            this.Close();
        }

    

        public List<Employee> GetAllEmployees()
        {
            return factory.GetAllEmployees();
        }

        public Employee GetEmployee(string username, string password)
        {
            return factory.GetEmployee(username, password);
        }

        public bool AddEmployee(Employee employee)
        {
            return factory.AddEmployee(employee);
        }

        public bool ChangeEmployeePostition(string username, Employee.PositionEnum position)
        {
            return factory.ChangeEmployeePostition(username, position);
        }

        public bool UpdateEmployee(Employee employee)
        {
            return factory.UpdateEmployee(employee);
        }

        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            return factory.ChangePassword(username, oldPassword, newPassword);
        }

        public bool EmployeeLogIn(string username)
        {
            return factory.EmployeeLogIn(username);
        }

        public bool EmployeeLogOut(string username)
        {
            return factory.EmployeeLogOut(username);
        }
    }
}
