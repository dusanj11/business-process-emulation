using Client.ViewModel;
using HiringCompanyData;
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
           

            string username = ClientDialogViewModel.Instance.LogInUser.Username;
            string password = ClientDialogViewModel.Instance.LogInUser.Password;


            if (username.Trim().Equals("") || username.Equals(null) ||
                password.Trim().Equals("") || password.Equals(null))
            {
                ClientDialogViewModel.Instance.ErrorMessage = "Niste popunili sva polja!";
            }
            else
            {
               

                using (ClientProxy proxy = new ClientProxy(WcfCommon.WcfAttributes.binding, WcfCommon.WcfAttributes.address))
                {
                    Employee outValue = proxy.GetEmployee(username, password);

                    if (outValue != null)
                    {

                        proxy.EmployeeLogIn(username);

                        if (outValue.Position.ToString().Equals("PO"))
                        {

                            if (outValue.PasswordUpadateDate > outValue.PasswordUpadateDate.AddMonths(6))
                            {
                                Application.Current.MainWindow.Hide();
                                ClientDialog cd = new ClientDialog();
                                cd.addEmployBtn.Visibility = Visibility.Collapsed;
                                cd.sendReqCompBtn.Visibility = Visibility.Collapsed;
                                cd.sendReqProjBtn.Visibility = Visibility.Collapsed;
                                cd.editPosBtn.Visibility = Visibility.Collapsed;
                                cd.showProjBtn.IsEnabled = false;
                                cd.showEmployBtn.IsEnabled = false;
                                cd.editYDBtn.IsEnabled = false;
                                cd.timeTableBtn.IsEnabled = false;
                                cd.passChngBtn.IsEnabled = true;
                                cd.createProjBtn.IsEnabled = false;
                                cd.defUSBtn.IsEnabled = false;
                                cd.showCompBtn.IsEnabled = false;
                                cd.Show();
                            }
                            else
                            {
                                //((Window)parameters[2]).Hide();
                                Application.Current.MainWindow.Hide();
                                ClientDialog cd = new ClientDialog();
                                cd.addEmployBtn.Visibility = Visibility.Collapsed;
                                cd.sendReqCompBtn.Visibility = Visibility.Collapsed;
                                cd.sendReqProjBtn.Visibility = Visibility.Collapsed;
                                cd.editPosBtn.Visibility = Visibility.Collapsed;
                                cd.showProjBtn.IsEnabled = true;
                                cd.showEmployBtn.IsEnabled = true;
                                cd.editYDBtn.IsEnabled = true;
                                cd.timeTableBtn.IsEnabled = true;
                                cd.passChngBtn.IsEnabled = true;
                                cd.createProjBtn.IsEnabled = true;
                                cd.defUSBtn.IsEnabled = true;
                                cd.showCompBtn.IsEnabled = true;
                                cd.Show();
                            }

                            
                        }
                        else if (outValue.Position.ToString().Equals("HR"))
                        {
                            if (outValue.PasswordUpadateDate > outValue.PasswordUpadateDate.AddMonths(6))
                            {
                                //((Window)parameters[2]).Hide();
                                Application.Current.MainWindow.Hide();
                                ClientDialog cd = new ClientDialog();
                                cd.showProjBtn.Visibility = Visibility.Collapsed;
                                cd.sendReqCompBtn.Visibility = Visibility.Collapsed;
                                cd.sendReqProjBtn.Visibility = Visibility.Collapsed;
                                cd.defUSBtn.Visibility = Visibility.Collapsed;
                                cd.createProjBtn.Visibility = Visibility.Collapsed;
                                cd.showEmployBtn.IsEnabled = false;
                                cd.addEmployBtn.IsEnabled = false;
                                cd.editYDBtn.IsEnabled = false;
                                cd.timeTableBtn.IsEnabled = false;
                                cd.passChngBtn.IsEnabled = true;
                                cd.showCompBtn.IsEnabled = false;
                                cd.editPosBtn.IsEnabled = false;
                                cd.Show();
                            }
                            else
                            {
                                //((Window)parameters[2]).Hide();
                                Application.Current.MainWindow.Hide();
                                ClientDialog cd = new ClientDialog();
                                cd.showProjBtn.Visibility = Visibility.Collapsed;
                                cd.sendReqCompBtn.Visibility = Visibility.Collapsed;
                                cd.sendReqProjBtn.Visibility = Visibility.Collapsed;
                                cd.defUSBtn.Visibility = Visibility.Collapsed;
                                cd.createProjBtn.Visibility = Visibility.Collapsed;
                                cd.showEmployBtn.IsEnabled = true;
                                cd.addEmployBtn.IsEnabled = true;
                                cd.editYDBtn.IsEnabled = true;
                                cd.timeTableBtn.IsEnabled = true;
                                cd.passChngBtn.IsEnabled = true;
                                cd.showCompBtn.IsEnabled = true;
                                cd.editPosBtn.IsEnabled = true;
                                cd.Show();
                            }
                        }
                        else if (outValue.Position.ToString().Equals("CEO"))
                        {
                            if (outValue.PasswordUpadateDate > outValue.PasswordUpadateDate.AddMonths(6))
                            {
                                //((Window)parameters[2]).Hide();
                                Application.Current.MainWindow.Hide();
                                ClientDialog cd = new ClientDialog();
                                cd.defUSBtn.Visibility = Visibility.Collapsed;
                                cd.createProjBtn.Visibility = Visibility.Collapsed;
                                cd.showProjBtn.IsEnabled = false;
                                cd.showEmployBtn.IsEnabled = false;
                                cd.addEmployBtn.IsEnabled = false;
                                cd.editYDBtn.IsEnabled = false;
                                cd.timeTableBtn.IsEnabled = false;
                                cd.passChngBtn.IsEnabled = true;
                                cd.sendReqCompBtn.IsEnabled = false;
                                cd.sendReqProjBtn.IsEnabled = false;
                                cd.showCompBtn.IsEnabled = false;
                                cd.editPosBtn.IsEnabled = false;
                                cd.Show();
                            }
                            else
                            {
                                //((Window)parameters[2]).Hide();
                                Application.Current.MainWindow.Hide();
                                ClientDialog cd = new ClientDialog();
                                cd.defUSBtn.Visibility = Visibility.Collapsed;
                                cd.createProjBtn.Visibility = Visibility.Collapsed;
                                cd.showProjBtn.IsEnabled = true;
                                cd.showEmployBtn.IsEnabled = true;
                                cd.addEmployBtn.IsEnabled = true;
                                cd.editYDBtn.IsEnabled = true;
                                cd.timeTableBtn.IsEnabled = true;
                                cd.passChngBtn.IsEnabled = true;
                                cd.sendReqCompBtn.IsEnabled = true;
                                cd.sendReqProjBtn.IsEnabled = true;
                                cd.showCompBtn.IsEnabled = true;
                                cd.editPosBtn.IsEnabled = true;
                                cd.Show();
                            }
                        }
                        else if (outValue.Position.ToString().Equals("SM"))
                        {
                            if (outValue.PasswordUpadateDate > outValue.PasswordUpadateDate.AddMonths(6))
                            {
                                //((Window)parameters[2]).Hide();
                                Application.Current.MainWindow.Hide();
                                ClientDialog cd = new ClientDialog();
                                cd.sendReqCompBtn.Visibility = Visibility.Collapsed;
                                cd.sendReqProjBtn.Visibility = Visibility.Collapsed;
                                cd.addEmployBtn.Visibility = Visibility.Collapsed;
                                cd.defUSBtn.Visibility = Visibility.Collapsed;
                                cd.createProjBtn.Visibility = Visibility.Collapsed;
                                cd.editPosBtn.Visibility = Visibility.Collapsed;
                                cd.showProjBtn.IsEnabled = false;
                                cd.showEmployBtn.IsEnabled = false;
                                cd.editYDBtn.IsEnabled = false;
                                cd.timeTableBtn.IsEnabled = false;
                                cd.passChngBtn.IsEnabled = true;
                                cd.showCompBtn.IsEnabled = false;
                                cd.Show();
                            }
                            else
                            {
                                //((Window)parameters[2]).Hide();
                                Application.Current.MainWindow.Hide();
                                ClientDialog cd = new ClientDialog();
                                cd.sendReqCompBtn.Visibility = Visibility.Collapsed;
                                cd.sendReqProjBtn.Visibility = Visibility.Collapsed;
                                cd.addEmployBtn.Visibility = Visibility.Collapsed;
                                cd.defUSBtn.Visibility = Visibility.Collapsed;
                                cd.createProjBtn.Visibility = Visibility.Collapsed;
                                cd.editPosBtn.Visibility = Visibility.Collapsed;
                                cd.showProjBtn.IsEnabled = true;
                                cd.showEmployBtn.IsEnabled = true;
                                cd.editYDBtn.IsEnabled = true;
                                cd.timeTableBtn.IsEnabled = true;
                                cd.passChngBtn.IsEnabled = true;
                                cd.showCompBtn.IsEnabled = true;
                                cd.Show();
                            }
                        }
                        else
                        {
                            ClientDialogViewModel.Instance.ErrorMessage = "Uneli ste nevalidne podatke. Pokušajte ponovo!";
                  
                        }
                    }
                    else
                    {
                        ClientDialogViewModel.Instance.ErrorMessage = "Uneli ste nevalidne podatke. Pokušajte ponovo!";
                        Console.WriteLine(ClientDialogViewModel.Instance.LogInUser.Username.ToString());
          
                    }
                }
            }
        }
    }
}