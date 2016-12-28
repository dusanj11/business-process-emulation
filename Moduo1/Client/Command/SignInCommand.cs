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
            ClientDialogViewModel cdvm = new ClientDialogViewModel();
            cdvm.ErrorMessage = "Niste uneli dobre podatke"; //TESTIRAJ OVO POSTO KOD KUCE NISI

            Object[] parameters = parameter as Object[];
            if(parameters == null || parameters.Length != 3 
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

                    Dictionary<String, Employee> employeeDictionary = employees.Distinct().ToDictionary(item => item.Username, item => item);

                    Employee outValue = null;
                    if(employeeDictionary.TryGetValue(parameters[0].ToString().Trim(), out outValue))
                    {
                        if(outValue.Password.Equals(parameters[1].ToString().Trim()))
                        {
                            if(outValue.Position.ToString().Equals("PO"))
                            {
                                ((Window)parameters[2]).Hide();
                                ClientDialog cd = new ClientDialog();
                                cd.addEmployBtn.Visibility = Visibility.Hidden;
                                cd.sendReqBtn.Visibility = Visibility.Hidden;
                                cd.Show();
                            }
                            else if(outValue.Position.ToString().Equals("HR"))
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

                        }
                        else
                        {

                            MessageBox.Show("Niste uneli dobre podatke!",
                                "greska",
                                 MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
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
