using Client.ViewModel;
using HiringCompanyContract.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.Windows.Input;

namespace Client.Command
{
    public class ViewWorkersCommand : ICommand
    {
        /// <summary>
        ///     WCF binding and address for communication with service
        /// </summary>
        private NetTcpBinding binding = new NetTcpBinding();
        private string address = "net.tcp://localhost:9090/HiringCompanyService";

        /// <summary>
        ///     Collection for mapping items to DataGrid
        /// </summary>
        private ObservableCollection<Employee> resources = new ObservableCollection<Employee>();

        private List<Employee> employees = new List<Employee>();

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            using (ClientProxy proxy = new ClientProxy(binding, address))
            {

                if (resources.Count != 0)
                {
                    resources.Clear();
                }
                employees = proxy.GetAllEmployees();

                foreach (Employee em in employees)
                {
                    resources.Add(em);
                }
                    

                ClientDialogViewModel.Instance.Resources = resources;
                ClientDialogViewModel.Instance.ShowEmployeeView();
            }
        }
    }
}
