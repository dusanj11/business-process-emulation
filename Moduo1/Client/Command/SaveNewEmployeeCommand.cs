using Client.Model;
using Client.ViewModel;
using HiringCompanyData;
using System;
using System.Threading;
using System.Windows.Input;

namespace Client.Command
{
    public class SaveNewEmployeeCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            NewEmployee newEmp = AddNewEmployeeViewModel.Instance.NewEmployee();

            Employee employee = new Employee();
            employee.Username = newEmp.Username;
            employee.Password = newEmp.Password;
            employee.Name = newEmp.Name;
            employee.Surname = newEmp.Surname;
            employee.StartTime = newEmp.StartTime;
            employee.EndTime = newEmp.EndTime;
            employee.Position = newEmp.Position;
            employee.PasswordUpadateDate = DateTime.Now;

            employee.HiringCompanyId = ClientProxy.Instance.GetHiringCompany(Thread.CurrentThread.ManagedThreadId);

            bool ret = ClientProxy.Instance.AddEmployee(employee);

            
        }
    }
}