using Client.ViewModel;
using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace Client.Command
{
    public class ShowCompaniesCommand : ICommand
    {
        private ObservableCollection<OutsourcingCompany> resources = new ObservableCollection<OutsourcingCompany>();

        public ObservableCollection<OutsourcingCompany> Resources
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
    


        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            List<OutsourcingCompany> OCResources = new List<OutsourcingCompany>();

            if (resources.Count != 0)
            {
                resources.Clear();
            }
            OCResources = ClientProxy.Instance.GetPartnershipOc(Thread.CurrentThread.ManagedThreadId);

            foreach (OutsourcingCompany oc in OCResources)
            {
                Resources.Add(oc);
            }

            ClientDialogViewModel.Instance.OcResources(Resources);
            ClientDialogViewModel.Instance.ShowShowCompaniesView();
        }
    }
}
