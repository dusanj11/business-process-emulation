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
            log.Info("Employee marked project as finished.");
            if (Resources.Count != 0)
            {
                Resources.Clear();
            }


            string username = ClientDialogViewModel.Instance.LogInUser().Username;

            log.Debug("proxy poziv - GetHcIdForUser");
            int hiringCompanyId = ClientProxy.Instance.GetHcIdForUser(username);
            log.Info("Successfully returned id of hiring company.");

            log.Debug("proxy poziv - GetHiringCompany");
            HiringCompany hc = ClientProxy.Instance.GetHiringCompany(hiringCompanyId);
            log.Info("Successfully returnedhiring company.");
            //int hiringCompanyId = hc.IDHc;
            log.Debug("proxy poziv - GetProjectsForHc");
            List<Project> list = ClientProxy.Instance.GetProjectsForHc(hiringCompanyId);
            log.Info("Successfully returned list of projects.");

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
