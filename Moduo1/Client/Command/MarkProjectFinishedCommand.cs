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

            HiringCompany hc = ClientProxy.Instance.GetHiringCompany(Thread.CurrentThread.ManagedThreadId);
            int hiringCompanyId = hc.IDHc;
            List<Project> list = ClientProxy.Instance.GetProjectsForHc(hiringCompanyId);

            foreach (Project p in list)
            {
                if (p.Progress == 100)
                {
                    Resources.Add(p);
                }
            }

            ClientDialogViewModel.Instance.PrResources(Resources);
            ClientDialogViewModel.Instance.ShowEndProjectView();
        }
    }
}
