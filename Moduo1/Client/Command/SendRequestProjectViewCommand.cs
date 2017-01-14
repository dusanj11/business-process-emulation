using Client.Model;
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
    /// <summary>
    /// samo omogucuje prikaz guia u glavnom prozoru
    /// </summary>
    public class SendRequestProjectViewCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

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

        public ObservableCollection<Project> PrResources
        {
            get
            {
                return prResources;
            }

            set
            {
                prResources = value;
            }
        }

        private ObservableCollection<Project> prResources = new ObservableCollection<Project>();

        public void Execute(object parameter)
        {
            Console.WriteLine("Izvrsavanje prikaya u toku");

            if (Resources.Count != 0)
            {
                Resources.Clear();
            }

            List<OutsourcingCompany> list = ClientProxy.Instance.GetPartnershipOc(Thread.CurrentThread.ManagedThreadId);

            LogInUser logInUser = ClientDialogViewModel.Instance.LogInUser();

            int hiringCompanyId = ClientProxy.Instance.GetHcIdForUser(logInUser.Username);

            List<Project> listP = ClientProxy.Instance.GetProjects(hiringCompanyId);

            Resources = new ObservableCollection<OutsourcingCompany>(list);
            PrResources = new ObservableCollection<Project>(listP);

            ClientDialogViewModel.Instance.PrResources(PrResources);
            ClientDialogViewModel.Instance.OcResources(Resources);
            ClientDialogViewModel.Instance.ShowSendRequestProjectView();
        }
    }
}
