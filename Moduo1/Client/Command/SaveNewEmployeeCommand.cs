using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Client.ViewModel;
using HiringCompanyData;
using Client.Model;
using System.ServiceModel;

namespace Client.Command
{
    public class SaveNewEmployeeCommand : ICommand
    {

        /// <summary>
        ///     WCF binding and address for communication with service
        /// </summary>
        private NetTcpBinding binding = new NetTcpBinding();
        private string address = "net.tcp://localhost:9090/HiringCompanyService";

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            using (ClientProxy proxy = new ClientProxy(binding, address))
            {

                NewEmployee newEmp = AddNewEmployeeViewModel.Instance.NewEmployee;

                Employee employee = new Employee();
                employee.Username = newEmp.Username;
                employee.Password = newEmp.Password;
                employee.Name = newEmp.Name;
                employee.Surname = newEmp.Surname;
                employee.StartTime = newEmp.StartTime;
                employee.EndTime = newEmp.EndTime;
                employee.Position = newEmp.Position;
                employee.PasswordUpadateDate = DateTime.Now;

                employee.HiringCompanyId = proxy.GetHiringCompany(Thread.CurrentThread.ManagedThreadId);

                bool ret = proxy.AddEmployee(employee);

              
            }
        }
    }
}
