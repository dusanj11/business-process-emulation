using Client.ViewModel;
using System;
using System.Windows.Input;

namespace Client.Command
{
    public class WorkingHoursCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            WorkingHoursViewModel.Instance.StartTime = string.Empty;
            WorkingHoursViewModel.Instance.EndTime = string.Empty;

            ClientDialogViewModel.Instance.ShowWorkingHoursView();
        }
    }
}