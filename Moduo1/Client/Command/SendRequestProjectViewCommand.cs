using Client.ViewModel;
using System;
using System.Collections.Generic;
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
    public class SendRequestProjectViewCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            Console.WriteLine("Izvrsavanje prikaya u toku");
            ClientDialogViewModel.Instance.ShowSendRequestProjectView();
        }
    }
}
