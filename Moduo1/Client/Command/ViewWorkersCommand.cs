using System;
using System.Collections.Generic;
using System.Windows.Input;
using HiringCompanyContract.Data;
using System.ServiceModel;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace Client.Command
{
    public class ViewWorkersCommand : ICommand
    {
        /// <summary>
        ///     WCF binding and address for communication with service
        /// </summary>
        NetTcpBinding binding = new NetTcpBinding();
        string address = "net.tcp://localhost:9090/HiringCompanyService";

        /// <summary>
        ///     Employee table view    
        /// </summary>
        public View.ShowEmployeeView _showEmployeeView;

        /// <summary>
        ///     Collection for mapping items to DataGrid
        /// </summary>
        ObservableCollection<Employee> resources = new ObservableCollection<Employee>();
       

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            using (ClientProxy proxy = new ClientProxy(binding, address))
            {

                List<Employee> employees = proxy.GetAllEmployees();

                foreach (Employee em in employees)
                    resources.Add(em);

                object[] parameters = parameter as object[];
                _showEmployeeView = new View.ShowEmployeeView();

                DockPanel docPanelClientDialog =  parameters[0] as DockPanel;

                try
                {
                    docPanelClientDialog.Children.RemoveAt(0);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Error {0}", e.Message);
                }
                

                _showEmployeeView.employeeDataGrid.ItemsSource = resources;

                docPanelClientDialog.Children.Add(_showEmployeeView);

                

                
            }
        }
    }
}
