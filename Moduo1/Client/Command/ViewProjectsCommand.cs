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
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
            Log.Info("Employee started viewing projects.");
            if (Resources.Count != 0)
            {
                Resources.Clear();
            }

            LogInUser logInUser = ClientDialogViewModel.Instance.LogInUser();

            Log.Debug("proxy poziv - GetEmployee");
            Employee emp = ClientProxy.Instance.GetEmployee(logInUser.Username, logInUser.Password);
            Log.Info("Successfully returned employee.");

            Log.Debug("proxy poziv - GetHcIdForUser");
            int hiringCompanyId = ClientProxy.Instance.GetHcIdForUser(logInUser.Username);
            Log.Info("Successfully returned hiring company id.");


            Log.Debug("proxy poziv - GetOutsourcingCompanyProjects");
            bool ret = ClientProxy.Instance.GetOutsourcingCompanyProjects(hiringCompanyId);
            Log.Info("Successfully done.");

            Log.Debug("proxy poziv - GetProjects");
            List<Project> projects = ClientProxy.Instance.GetProjects(hiringCompanyId);
            Log.Info("Successfully returned list of projects.");



            foreach (Project p in projects)
            {
                
                Resources.Add(p);
            }

            ClientDialogViewModel.Instance.PrResources(Resources);
            ClientDialogViewModel.Instance.ShowShowProjectsView();
        }
    }
}