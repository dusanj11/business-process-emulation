using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.ServiceModel;
using HiringCompanyContract.Data;

namespace Client.Command
{
    public class AddEmployeeCommand : ICommand
    {
        NetTcpBinding binding = new NetTcpBinding();
        string address = "net.tcp://localhost:9090/HiringCompanyService";

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            
        }
    }
}
