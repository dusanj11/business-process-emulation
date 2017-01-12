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

            if (Resources.Count != 0)
            {
                Resources.Clear();
            }

            // preuzmi projekte kompanija sa kojima ima partnerstvo 
            List<Project> partnershipProject = new List<Project>();
            int hiringCompanyTh = Thread.CurrentThread.ManagedThreadId;

            partnershipProject = ClientProxy.Instance.GetPartnershipProjects(hiringCompanyTh);

            foreach (Project p in partnershipProject)
            {
                Resources.Add(p);
            }

            ClientDialogViewModel.Instance.PrResources(Resources);

            ClientDialogViewModel.Instance.ShowDefineUserStoriesView();
        }
    }
}
