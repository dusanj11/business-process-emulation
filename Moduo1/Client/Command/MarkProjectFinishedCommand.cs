using Client.ViewModel;
using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Command
{
    public class MarkProjectFinishedCommand : ICommand
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
            Log.Info("Employee marked project as finished.");
            if (Resources.Count != 0)
            {
                Resources.Clear();
            }


            string username = ClientDialogViewModel.Instance.LogInUser().Username;

            Log.Debug("proxy poziv - GetHcIdForUser");
            int hiringCompanyId = ClientProxy.Instance.GetHcIdForUser(username);
            Log.Info("Successfully returned id of hiring company.");

            Log.Debug("proxy poziv - GetHiringCompany");
            HiringCompany hc = ClientProxy.Instance.GetHiringCompany(hiringCompanyId);
            Log.Info("Successfully returnedhiring company.");
            //int hiringCompanyId = hc.IDHc;
            Log.Debug("proxy poziv - GetProjectsForHc");
            List<Project> list = ClientProxy.Instance.GetProjectsForHc(hiringCompanyId);
            Log.Info("Successfully returned list of projects.");

            foreach (Project p in list)
            {
                if (p.Progress == 100 && !p.Ended)
                {
                    Resources.Add(p);
                }
            }

            ClientDialogViewModel.Instance.PrResources(Resources);
            ClientDialogViewModel.Instance.ShowEndProjectView();
        }
    }
}
