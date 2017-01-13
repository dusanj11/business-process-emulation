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
        private ObservableCollection<HiringCompanyData.OutsourcingCompany> resources = new ObservableCollection<HiringCompanyData.OutsourcingCompany>();

        public ObservableCollection<HiringCompanyData.OutsourcingCompany> Resources
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
            List<HiringCompanyData.OutsourcingCompany> OCResources = new List<HiringCompanyData.OutsourcingCompany>();

            if (resources.Count != 0)
            {
                resources.Clear();
            }
            OCResources = ClientProxy.Instance.GetPartnershipOc(Thread.CurrentThread.ManagedThreadId);

            foreach (HiringCompanyData.OutsourcingCompany oc in OCResources)
            {
                Resources.Add(oc);
            }

            ClientDialogViewModel.Instance.OcResources(Resources);
            ClientDialogViewModel.Instance.ShowShowCompaniesView();
        }
    }
}
