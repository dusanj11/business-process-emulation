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
        private NetTcpBinding binding = new NetTcpBinding();
        private string address = "net.tcp://localhost:9090/HiringCompanyService";

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        //DA LI OVO TREBA OVDE UOPSTE TREBA DEO SA PROKSIJEM
        public void Execute(object parameter)
        {
            using (ClientProxy proxy = new ClientProxy(binding, address)) 
            {
                ClientDialogViewModel.Instance.ShowAddEmployeeView();
            }
        }
    }
}
