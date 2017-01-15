using Client.ViewModel;
using System;
using System.Windows.Input;

namespace Client.Command
{
    public class WorkingHoursCommand : ICommand
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {

            log.Info("Eployee started to edit working hours.");
            ClientDialogViewModel.Instance.ShowWorkingHoursView();
        }
    }
}