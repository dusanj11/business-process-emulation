using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using HiringCompanyContract.Data;
using System.ServiceModel;
using Client.ViewModel;
using System.Windows.Controls;

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
            if(parameters == null || parameters.Length != 4 
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

                    Dictionary<String, Employee> employeeDictionary = employees.Distinct().ToDictionary(item => item.Username, item => item);

                    Employee outValue = null;
                    if(employeeDictionary.TryGetValue(parameters[0].ToString().Trim(), out outValue))
                    {
                        if(outValue.Password.Equals(((PasswordBox)parameters[1]).Password.ToString().Trim()))
                        {
                            if(outValue.Position.ToString().Equals("PO"))
                            {
                                ((Window)parameters[2]).Hide();
                                ClientDialog cd = new ClientDialog();
                                cd.addEmployBtn.Visibility = Visibility.Collapsed;
                                cd.sendReqCompBtn.Visibility = Visibility.Collapsed;
                                cd.sendReqProjBtn.Visibility = Visibility.Collapsed;
                                cd.Show();
                            }
                            else if(outValue.Position.ToString().Equals("HR"))
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

                        }
                        else
                        {
                            ((Label)parameters[3]).Content = "Uneli ste nevalidne podatke. Pokušajte ponovo!";
                            //MessageBox.Show("Niste uneli dobre podatke!",
                            //    "greska",
                            //     MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        ((Label)parameters[3]).Content = "Uneli ste nevalidne podatke. Pokušajte ponovo!";
                        //MessageBox.Show("Niste uneli dobre podatke!",
                        //        "greska",
                        //         MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
            }


        }
    }
}
