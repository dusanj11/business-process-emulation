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

            bool ret = ClientProxy.Instance.GetOutsourcingCompanyProjects(Thread.CurrentThread.ManagedThreadId);


            List<Project> projects = ClientProxy.Instance.GetProjects();

            foreach (Project p in projects)
            {
                Resources.Add(p);
            }

            ClientDialogViewModel.Instance.PrResources(Resources);
            ClientDialogViewModel.Instance.ShowShowProjectsView();
        }
    }
}