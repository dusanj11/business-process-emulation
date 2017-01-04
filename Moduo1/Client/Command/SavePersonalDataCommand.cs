using Client.ViewModel;
using HiringCompanyContract.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Command
{
    public class SavePersonalDataCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string name = EditPersonalDataViewModel.Instance.Name;
            string surname = EditPersonalDataViewModel.Instance.Surname;
            string username = EditPersonalDataViewModel.Instance.Username;

            string loginUsername = ClientDialogViewModel.Instance.LogInUser.Username;
            string loginPassword = ClientDialogViewModel.Instance.LogInUser.Password;

            using (ClientProxy proxy = new ClientProxy(WcfCommon.WcfAttributes.binding, WcfCommon.WcfAttributes.address))
            {
                Employee employee = proxy.GetEmployee(loginUsername, loginPassword);

                employee.Name = name;
                employee.Surname = surname;
                employee.Username = username;

                proxy.UpdateEmployee(employee);
            }
        }
    }
}
