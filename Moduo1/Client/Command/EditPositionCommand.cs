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
            if (Resources.Count != 0)
            {
                Resources.Clear();
            }

            List<Employee> logInEmployees = new List<Employee>(50);

            logInEmployees = ClientProxy.Instance.GetAllEmployees();

            List<Employee> noLogInEmployees = ClientProxy.Instance.GetAllNotSignedInEmployees();

            foreach (Employee em in logInEmployees)
            {
                Resources.Add(em);
            }

            foreach (Employee nem in noLogInEmployees)
            {
                Resources.Add(nem);
            }

            ClientDialogViewModel.Instance.EmpResource = Resources;
            ClientDialogViewModel.Instance.ShowEditPositionView();
        }
    }
}