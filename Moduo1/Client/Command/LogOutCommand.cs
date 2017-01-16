using Client.ViewModel;
using System;
using System.Windows;
using System.Windows.Input;

namespace Client.Command
{
    public class LogOutCommand : ICommand
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            Log.Info("Employee is loging out");
            string username = ClientDialogViewModel.Instance.LogInUser().Username;

            if (username.Equals("") || username.Equals(null))
            {
                return;
            }

            Log.Debug("proxy poziv - EmployeeLogIn");
            ClientProxy.Instance.EmployeeLogOut(username);
            Log.Info("Successfully logged user out");

            Application.Current.Windows[1].Close();
            Application.Current.MainWindow.Show();
            ClientDialogViewModel.Instance.LogInUser().Username = string.Empty;
            ClientDialogViewModel.Instance.LogInUser().Password = string.Empty;
        }
    }
}