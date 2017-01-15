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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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

            LogInUser logInUser = ClientDialogViewModel.Instance.LogInUser();

            log.Debug("proxy poziv - GetHcIdForUser");
            int hiringCompanyId = ClientProxy.Instance.GetHcIdForUser(logInUser.Username);
            log.Info("Succesfully returned hiring company id.");

            log.Debug("proxy poziv - GetPartnershipOc");
            List<OutsourcingCompany> list = ClientProxy.Instance.GetPartnershipOc(hiringCompanyId);
            log.Info("Succesfully returned list of Outsourcing companies.");

            log.Debug("proxy poziv - GetProjects");
            List<Project> listP = ClientProxy.Instance.GetProjects(hiringCompanyId);
            log.Info("Succesfully returned list of projects.");

            Resources = new ObservableCollection<OutsourcingCompany>(list);
            PrResources = new ObservableCollection<Project>(listP);

            ClientDialogViewModel.Instance.PrResources(PrResources);
            ClientDialogViewModel.Instance.OcResources(Resources);
            ClientDialogViewModel.Instance.ShowSendRequestProjectView();
        }
    }
}
