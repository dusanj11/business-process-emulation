using Client.ViewModel;
using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Input;

namespace Client.Command
{
    public class DefineUserStoriesCommand : ICommand
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Log.Info("Employee started accepting/rejecting user stories.");
            if (Resources.Count != 0)
            {
                Resources.Clear();
            }

            // preuzmi projekte kompanija sa kojima ima partnerstvo 
            List<Project> partnershipProject = new List<Project>();

            string username = ClientDialogViewModel.Instance.LogInUser().Username;


            Log.Debug("proxy poziv - GetHcIdForUser");
            int hiringCompanyTh = ClientProxy.Instance.GetHcIdForUser(username);
            Log.Info("Successfully returned Hiring company Id");
            Log.Debug("proxy poziv - GetPartnershipProjects");
            partnershipProject = ClientProxy.Instance.GetPartnershipProjects(hiringCompanyTh);
            Log.Info("Successfully returned list of partnership projects.");
            foreach (Project p in partnershipProject)
            {
                Resources.Add(p);
            }

            ClientDialogViewModel.Instance.PrResources(Resources);

            ClientDialogViewModel.Instance.ShowDefineUserStoriesView();
        }
    }
}
