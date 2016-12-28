using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Configuration;
using HiringCompanyContract.Data;
using System.Data.SqlClient;
using System.ServiceModel;
using System.Windows.Controls;

namespace Client.Command
{
    public class ViewWorkersCommand : ICommand
    {
        /// <summary>
        ///  WCF binding and address for communication with service
        /// </summary>
        NetTcpBinding binding = new NetTcpBinding();
        string address = "net.tcp://localhost:9090/HiringCompanyService";

        public View.ShowEmployeeView _showEmployeeView;
        public Control _currentControl;
       

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

                _showEmployeeView = new View.ShowEmployeeView();

                

            }
        }
    }
}
