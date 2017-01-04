using Client.ViewModel;
using System;
using System.ServiceModel;
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
                ClientDialogViewModel.Instance.ShowAddEmployeeView();
            }
        }
    }
