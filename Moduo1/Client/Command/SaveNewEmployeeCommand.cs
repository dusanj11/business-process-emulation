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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            log.Info("Employee saved new employee");
            NewEmployee newEmp = AddNewEmployeeViewModel.Instance.NewEmployee();

            Employee employee = new Employee();
            employee.Username = newEmp.Username;
            employee.Password = newEmp.Password;
            employee.Name = newEmp.Name;
            employee.Surname = newEmp.Surname;
            employee.StartTime = Parser.Parse(newEmp.StartTime);
            employee.EndTime = Parser.Parse(newEmp.EndTime);
            employee.Position = Parser.Parse(newEmp.Position);
            employee.PasswordUpadateDate = DateTime.Now;
            employee.Email = newEmp.Email;

            string username = ClientDialogViewModel.Instance.LogInUser().Username;

            log.Debug("proxy poziv - GetHcIdForUser");
            int hiringCompanyId = ClientProxy.Instance.GetHcIdForUser(username);
            log.Info("Successfully returned id of hiring company");


            log.Debug("proxy poziv - GetHcIdForUser");
            employee.HiringCompanyId = ClientProxy.Instance.GetHiringCompany(hiringCompanyId);
            log.Info("Successfully returned  hiring company");

            log.Debug("proxy poziv - GetHcIdForUser");
            bool ret = ClientProxy.Instance.AddEmployee(employee);
            log.Info("Successfully added employee");



        }
    }
}