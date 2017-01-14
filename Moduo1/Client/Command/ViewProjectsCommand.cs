using Client.Model;
using Client.ViewModel;
using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Input;

namespace Client.Command
{
    public class ViewProjectsCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        private ObservableCollection<Project> resources = new ObservableCollection<Project>();

        public ObservableCollection<Project> Resources
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

        public void Execute(object parameter)
        {
            if (Resources.Count != 0)
            {
                Resources.Clear();
            }

            LogInUser logInUser = ClientDialogViewModel.Instance.LogInUser();

            Employee emp = ClientProxy.Instance.GetEmployee(logInUser.Username, logInUser.Password);

            int hiringCompanyId = ClientProxy.Instance.GetHcIdForUser(logInUser.Username);

            bool ret = ClientProxy.Instance.GetOutsourcingCompanyProjects(hiringCompanyId);
            List<Project> projects = ClientProxy.Instance.GetProjects(hiringCompanyId);

            

            foreach (Project p in projects)
            {
                
                Resources.Add(p);
            }

            ClientDialogViewModel.Instance.PrResources(Resources);
            ClientDialogViewModel.Instance.ShowShowProjectsView();
        }
    }
}