using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Client.Command
{
    public class LogOutCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            string username = ClientDialogViewModel.Instance.LogInUser.Username;

            if (username.Equals("") || username.Equals(null))
                return;

            using (ClientProxy proxy = new ClientProxy(WcfCommon.WcfAttributes.binding, WcfCommon.WcfAttributes.address))
            {
                proxy.EmployeeLogOut(username);

                
                Application.Current.Windows[1].Close();          
                Application.Current.MainWindow.Show();
                ClientDialogViewModel.Instance.LogInUser.Username = string.Empty;
                ClientDialogViewModel.Instance.LogInUser.Password = string.Empty;

            }
        }
    }
}
