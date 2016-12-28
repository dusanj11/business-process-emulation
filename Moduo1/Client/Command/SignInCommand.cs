using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using HiringCompanyContract.Data;
using System.ServiceModel;

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
            else
            {
                NetTcpBinding binding = new NetTcpBinding();
                string address = "net.tcp://localhost:9090/HiringCompanyService";

                using(ClientProxy proxy = new ClientProxy(binding, address))
                {
                    List<Employee> employees = proxy.GetAllEmployees();
                    if(employees == null || employees.Count == 0)
                    {
                        MessageBox.Show("Nema baze trenutno!",
                                "Greska",
                                 MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    foreach(Employee em in employees)
                    {
                        if(!parameters[0].ToString().Trim().Equals(em.Username) 
                            || !parameters[1].ToString().Trim().Equals(em.Password))
                        {
                            MessageBox.Show("Niste uneli dobre podatke!",
                                "greska",
                                 MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }


        }
    }
}
