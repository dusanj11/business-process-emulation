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

                    Employee outValue = proxy.GetEmployee(parameters[0].ToString().Trim(), ((PasswordBox)parameters[1]).Password.ToString().Trim());

                    if (outValue != null)
                        {
                        if (outValue.Position.ToString().Equals("PO"))
                            {
                                ((Window)parameters[2]).Hide();
                                ClientDialog cd = new ClientDialog();
                                cd.addEmployBtn.Visibility = Visibility.Collapsed;
                                cd.sendReqCompBtn.Visibility = Visibility.Collapsed;
                                cd.sendReqProjBtn.Visibility = Visibility.Collapsed;
                                cd.Show();
                            }
                        else if (outValue.Position.ToString().Equals("HR"))
                            {
                                ((Window)parameters[2]).Hide();
                                ClientDialog cd = new ClientDialog();
                                cd.showProjBtn.Visibility = Visibility.Collapsed;
                                cd.sendReqCompBtn.Visibility = Visibility.Collapsed;
                                cd.sendReqProjBtn.Visibility = Visibility.Collapsed;
                                cd.defUSBtn.Visibility = Visibility.Collapsed;
                                cd.createProjBtn.Visibility = Visibility.Collapsed;
                                cd.Show();
                            }
                            else if (outValue.Position.ToString().Equals("CEO"))
                            {
                                ((Window)parameters[2]).Hide();
                                ClientDialog cd = new ClientDialog();
                                cd.defUSBtn.Visibility = Visibility.Collapsed;
                                cd.createProjBtn.Visibility = Visibility.Collapsed;
                                cd.Show();
                            }
                            else if (outValue.Position.ToString().Equals("SM"))
                            {
                                ((Window)parameters[2]).Hide();
                                ClientDialog cd = new ClientDialog();
                                cd.sendReqCompBtn.Visibility = Visibility.Collapsed;
                                cd.sendReqProjBtn.Visibility = Visibility.Collapsed;
                                cd.addEmployBtn.Visibility = Visibility.Collapsed;
                                cd.defUSBtn.Visibility = Visibility.Collapsed;
                                cd.createProjBtn.Visibility = Visibility.Collapsed;
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
