using Client.ViewModel;
using HiringCompanyData;
using System;
using System.Windows.Input;

namespace Client.Command
{
    public class SaveWorkingHoursCommand : ICommand
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Log.Info("Employee saved working hours.");
            string username = ClientDialogViewModel.Instance.LogInUser().Username;
            string password = ClientDialogViewModel.Instance.LogInUser().Password;

            string startTime = WorkingHoursViewModel.Instance.StartTime();
            string endTime = WorkingHoursViewModel.Instance.EndTime();

            Log.Debug("proxy poziv - GetEmployee");
            Employee em = ClientProxy.Instance.GetEmployee(username, password);
            Log.Info("Successfully returned employee.");

            if (em != null)
            {
                em.StartTime = Parser.Parse(startTime);
                em.EndTime = Parser.Parse(endTime);

                Log.Debug("proxy poziv - UpdateEmployee");
                ClientProxy.Instance.UpdateEmployee(em);
                Log.Info("Successfully updated employee.");
            }
        }
    }
}