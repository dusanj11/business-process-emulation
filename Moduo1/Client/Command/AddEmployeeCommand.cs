using Client.ViewModel;
using System;
using System.Windows.Input;

namespace Client.Command
{
    public class AddEmployeeCommand : ICommand
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            Log.Info("Employee started adding new employee.");
            AddNewEmployeeViewModel.Instance.NewEmployee().Username = string.Empty;
            AddNewEmployeeViewModel.Instance.NewEmployee().Password = string.Empty;
            AddNewEmployeeViewModel.Instance.NewEmployee().Name = string.Empty;
            AddNewEmployeeViewModel.Instance.NewEmployee().Surname = string.Empty;
            AddNewEmployeeViewModel.Instance.NewEmployee().StartTime = string.Empty;
            AddNewEmployeeViewModel.Instance.NewEmployee().EndTime = string.Empty;
            AddNewEmployeeViewModel.Instance.NewEmployee().Position = string.Empty;
            AddNewEmployeeViewModel.Instance.NewEmployee().Email = string.Empty;
            ClientDialogViewModel.Instance.ShowAddEmployeeView();
        }
    }
}