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
            Console.WriteLine("Izvrsavanje prikaya u toku");

            if (Resources.Count != 0)
            {
                Resources.Clear();
            }

            List<OutsourcingCompany> oclist = ClientProxy.Instance.GetOutsourcingCompanies();

            Resources = new ObservableCollection<OutsourcingCompany>(oclist);

            ClientDialogViewModel.Instance.OcResources(Resources);
            ClientDialogViewModel.Instance.ShowSendRequestCompanyView();
        }
    }
}
