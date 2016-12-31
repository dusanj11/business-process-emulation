using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.ServiceModel;
using System.Windows.Controls;
using Client.ViewModel;

namespace Client.Command
{
    public class AddEmployeeCommand : ICommand
    {
        /// <summary>
        ///     WCF binding and address for communication with service
        /// </summary>
        NetTcpBinding binding = new NetTcpBinding();
        string address = "net.tcp://localhost:9090/HiringCompanyService";

        /// <summary>
        ///     Employee table view    
        /// </summary>
        public View.AddEmployeeView addEmployeeView;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            //MessageBox.Show("U izradi dodavanje zaposlenog");
            using (ClientProxy proxy = new ClientProxy(binding, address)) //DA LI OVO TREBA OVDE UOPSTE
            {
               

                //object[] parameters = parameter as object[];
                //addEmployeeView = new View.AddEmployeeView();

                //DockPanel docPanelClientDialog = parameters[0] as DockPanel;

                //try
                //{
                //    docPanelClientDialog.Children.RemoveAt(0);
                //}
                //catch(Exception e)
                //{
                //    Console.WriteLine("Error {0}", e.Message);
                //}

                //docPanelClientDialog.Children.Add(addEmployeeView);

                ClientDialogViewModel.Instance.ShowAddEmployeeView();
            }
        }
    }
}
