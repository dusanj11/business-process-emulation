using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using HiringCompanyContract.Data;

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

            ClientDialogViewModel.Instance.ShowWorkingHoursView();
            
        }
    }
}
