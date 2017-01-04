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
    public class ChangePasswordCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            ChangePasswordViewModel.Instance.OldPassword = string.Empty;
            ChangePasswordViewModel.Instance.NewPassword = string.Empty;

            ClientDialogViewModel.Instance.ShowChangePasswordView();
        }
    }
}
