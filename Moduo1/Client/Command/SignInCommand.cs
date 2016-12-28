using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Client.Command
{
    public class SignInCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            Object[] parameters = parameter as Object[];
            if(parameters == null || parameters.Length != 2 
                || parameters[0].ToString().Trim().Equals("")
                || parameters[1].ToString().Trim().Equals(""))
            {
                MessageBox.Show("Niste popunili sva polja!",
                                "Upozorenje",
                                 MessageBoxButton.OK, MessageBoxImage.Information);
                //lolololo
            }


        }
    }
}
