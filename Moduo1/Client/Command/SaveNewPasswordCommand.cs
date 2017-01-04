using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Command
{
    public class SaveNewPasswordCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string oldPassword = ChangePasswordViewModel.Instance.OldPassword;
            string newPassword = ChangePasswordViewModel.Instance.NewPassword;

            string username = ClientDialogViewModel.Instance.LogInUser.Username;

            using (ClientProxy proxy = new ClientProxy(WcfCommon.WcfAttributes.binding, WcfCommon.WcfAttributes.address))
            {
                bool ret = proxy.ChangePassword(username, oldPassword, newPassword);

                if (ret)
                {
                    ClientDialogViewModel.Instance.LogInUser.Password = newPassword;
                }
            }
        }
    }
}
