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
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Log.Info("Employee saved new employee");
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

            Log.Debug("proxy poziv - GetHcIdForUser");
            int hiringCompanyId = ClientProxy.Instance.GetHcIdForUser(username);
            Log.Info("Successfully returned id of hiring company");


            Log.Debug("proxy poziv - GetHcIdForUser");
            employee.HiringCompanyId = ClientProxy.Instance.GetHiringCompany(hiringCompanyId);
            Log.Info("Successfully returned  hiring company");

            Log.Debug("proxy poziv - GetHcIdForUser");
            bool ret = ClientProxy.Instance.AddEmployee(employee);
            Log.Info("Successfully added employee");



        }
    }
}