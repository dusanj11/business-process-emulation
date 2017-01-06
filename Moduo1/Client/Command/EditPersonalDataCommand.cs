using Client.ViewModel;
using HiringCompanyData;
using System;
using System.Windows.Input;
using WcfCommon;

namespace Client.Command
{
    public class EditPersonalDataCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            string username = ClientDialogViewModel.Instance.LogInUser.Username;
            string password = ClientDialogViewModel.Instance.LogInUser.Password;

            Employee employeeFromDB;

            using (ClientProxy proxy = new ClientProxy(WcfAttributes.binding, WcfAttributes.address))
            {
                employeeFromDB = proxy.GetEmployee(username, password);

                EditPersonalDataViewModel.Instance.Name = employeeFromDB.Name;
                EditPersonalDataViewModel.Instance.Surname = employeeFromDB.Surname;
                EditPersonalDataViewModel.Instance.Username = employeeFromDB.Username;
            }

            ClientDialogViewModel.Instance.ShowEditPersonalDataView();
        }
    }
}