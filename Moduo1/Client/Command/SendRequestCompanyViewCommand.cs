using Client.ViewModel;
using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Client.Command
{
    /// <summary>
    /// samo omogucuje prikaz guia u glavnom prozoru
    /// </summary>
    public class SendRequestCompanyViewCommand : ICommand
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

        public void Execute(object parameter)
        {
            log.Info("Employee stated sending request to comapny.");
            Console.WriteLine("Izvrsavanje prikaya u toku");

            if (Resources.Count != 0)
            {
                Resources.Clear();
            }

            log.Debug("proxy poziv - GetOutsourcingCompanies");
            List<OutsourcingCompany> oclist = ClientProxy.Instance.GetOutsourcingCompanies();
            log.Info("Successfully retunr list of outsorucing companies");

            Resources = new ObservableCollection<OutsourcingCompany>(oclist);

            ClientDialogViewModel.Instance.OcResources(Resources);
            ClientDialogViewModel.Instance.ShowSendRequestCompanyView();
        }
    }
}
