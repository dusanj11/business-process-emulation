using Client.ViewModel;
using HiringCompanyData;
using System;
using System.Windows.Input;

namespace Client.Command
{
    public class SaveWorkingHoursCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string username = ClientDialogViewModel.Instance.LogInUser().Username;
            string password = ClientDialogViewModel.Instance.LogInUser().Password;

            string startTime = WorkingHoursViewModel.Instance.StartTime();
            string endTime = WorkingHoursViewModel.Instance.EndTime();

            Employee em = ClientProxy.Instance.GetEmployee(username, password);
            if (em != null)
            {
                em.StartTime = startTime;
                em.EndTime = endTime;

                ClientProxy.Instance.UpdateEmployee(em);
            }
        }
    }
}