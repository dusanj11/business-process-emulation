using Client.ViewModel;
using System;
using System.Windows.Input;

namespace Client.Command
{
    public class AddEmployeeCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
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