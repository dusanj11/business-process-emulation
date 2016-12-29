using HiringCompanyContract.Data;
using System;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
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
            if (parameters == null || parameters.Length != 4
                || parameters[0].ToString().Trim().Equals("")
                || parameters[1].ToString().Trim().Equals(""))
            {
                MessageBox.Show("Niste popunili sva polja!",
                                "Upozorenje",
                                 MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                NetTcpBinding binding = new NetTcpBinding();
                string address = "net.tcp://localhost:9090/HiringCompanyService";

                using (ClientProxy proxy = new ClientProxy(binding, address))
                {

                    Employee outValue = proxy.GetEmployee(parameters[0].ToString().Trim(), parameters[1].ToString().Trim());
                   
                    if (outValue != null)
                    {
                        if (outValue.Position.ToString().Equals("PO"))
                        {
                            ((Window)parameters[2]).Hide();
                            ClientDialog cd = new ClientDialog();
                            cd.addEmployBtn.Visibility = Visibility.Hidden;
                            cd.sendReqBtn.Visibility = Visibility.Hidden;
                            cd.Show();
                        }
                        else if (outValue.Position.ToString().Equals("HR"))
                        {
                            ((Window)parameters[2]).Hide();
                            ClientDialog cd = new ClientDialog();
                            cd.sendReqBtn.Visibility = Visibility.Hidden;
                            cd.defUSBtn.Visibility = Visibility.Hidden;
                            cd.createProjBtn.Visibility = Visibility.Hidden;
                            cd.Show();
                        }
                        else if (outValue.Position.ToString().Equals("CEO"))
                        {
                            ((Window)parameters[2]).Hide();
                            ClientDialog cd = new ClientDialog();
                            cd.sendReqBtn.Visibility = Visibility.Hidden;
                            cd.defUSBtn.Visibility = Visibility.Hidden;
                            cd.createProjBtn.Visibility = Visibility.Hidden;
                            cd.Show();
                        }
                        else if (outValue.Position.ToString().Equals("SM"))
                        {
                            ((Window)parameters[2]).Hide();
                            ClientDialog cd = new ClientDialog();
                            cd.sendReqBtn.Visibility = Visibility.Hidden;
                            cd.addEmployBtn.Visibility = Visibility.Hidden;
                            cd.defUSBtn.Visibility = Visibility.Hidden;
                            cd.createProjBtn.Visibility = Visibility.Hidden;
                            cd.Show();
                        }
                        else
                        {
                            ((Label)parameters[3]).Content = "Uneli ste nevalidne podatke. Pokušajte ponovo!";
                        }
                    }
                    else
                    {
                        ((Label)parameters[3]).Content = "Uneli ste nevalidne podatke. Pokušajte ponovo!";
                    }
                }
            }
        }
    }
}