using Client.ViewModel;
using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Client.Command
{
    public class EditPositionCommand : ICommand
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public event EventHandler CanExecuteChanged;

        private ObservableCollection<Employee> resources = new ObservableCollection<Employee>();

        public ObservableCollection<Employee> Resources
        {
            get
            {
                return resources;
            }

            set
            {
                resources = value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Log.Info("Employee started editing employee's position");
            if (Resources.Count != 0)
            {
                Resources.Clear();
            }

            List<Employee> logInEmployees = new List<Employee>(50);

            Log.Debug("proxy poziv - GetAllEmployees ");
            logInEmployees = ClientProxy.Instance.GetAllEmployees();
            Log.Info("Successfully returned all logged employees");

            Log.Debug("proxy poziv - GetAllotSignedInEmployees ");
            List<Employee> noLogInEmployees = ClientProxy.Instance.GetAllNotSignedInEmployees();
            Log.Info("Successfully returned all not logged employees");
            foreach (Employee em in logInEmployees)
            {
                Resources.Add(em);
            }

            foreach (Employee nem in noLogInEmployees)
            {
                Resources.Add(nem);
            }

            ClientDialogViewModel.Instance.EmpResources(Resources);
            ClientDialogViewModel.Instance.ShowEditPositionView();
        }
    }
}