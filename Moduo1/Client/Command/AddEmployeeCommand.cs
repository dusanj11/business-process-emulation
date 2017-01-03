using Client.ViewModel;
using System;
using System.ServiceModel;
using System.Windows.Input;

namespace Client.Command
{
    public class AddEmployeeCommand : ICommand
    {
        /// <summary>
        ///     WCF binding and address for communication with service
        /// </summary>
        private NetTcpBinding binding = new NetTcpBinding();

        private string address = "net.tcp://localhost:9090/HiringCompanyService";

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
            ClientDialogViewModel.Instance.ShowAddEmployeeView();
        }
    }
}