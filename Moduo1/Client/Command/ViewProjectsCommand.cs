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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
            log.Info("Employee started viewing projects.");
            if (Resources.Count != 0)
            {
                Resources.Clear();
            }

            LogInUser logInUser = ClientDialogViewModel.Instance.LogInUser();

            log.Debug("proxy poziv - GetEmployee");
            Employee emp = ClientProxy.Instance.GetEmployee(logInUser.Username, logInUser.Password);
            log.Info("Successfully returned employee.");

            log.Debug("proxy poziv - GetHcIdForUser");
            int hiringCompanyId = ClientProxy.Instance.GetHcIdForUser(logInUser.Username);
            log.Info("Successfully returned hiring company id.");


            log.Debug("proxy poziv - GetOutsourcingCompanyProjects");
            bool ret = ClientProxy.Instance.GetOutsourcingCompanyProjects(hiringCompanyId);
            log.Info("Successfully done.");

            log.Debug("proxy poziv - GetProjects");
            List<Project> projects = ClientProxy.Instance.GetProjects(hiringCompanyId);
            log.Info("Successfully returned list of projects.");



            foreach (Project p in projects)
            {
                
                Resources.Add(p);
            }

            ClientDialogViewModel.Instance.PrResources(Resources);
            ClientDialogViewModel.Instance.ShowShowProjectsView();
        }
    }
}