﻿using Client.ViewModel;
using HiringCompanyData;
using System;
using System.ServiceModel;
using System.Windows.Input;

namespace Client.Command
{
    public class EditPersonalDataCommand : ICommand
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            Log.Info("Employee started editing personal information.");
            try
            {
                string username = ClientDialogViewModel.Instance.LogInUser().Username;
                string password = ClientDialogViewModel.Instance.LogInUser().Password;

                Employee employeeFromDB;

                try
                {
                    employeeFromDB = ClientProxy.Instance.GetEmployee(username, password);

                    EditPersonalDataViewModel.Instance.Name(employeeFromDB.Name);
                    EditPersonalDataViewModel.Instance.Surname(employeeFromDB.Surname);
                    EditPersonalDataViewModel.Instance.Username(employeeFromDB.Username);

                    Log.Info("Successfully returned employee personal data.");
                }
                catch (CommunicationException ce)
                {
                    Console.WriteLine("Error: CommunicationException {0}", ce.Message);
                    Log.Error("Communication Exception while trying to return employee personal data.");
                }
                catch (Exception e)
                {
                    Log.Error("Exception while trying to return employee personal data.");
                    Console.WriteLine("Error: {0}", e.Message);
                }

                ClientDialogViewModel.Instance.ShowEditPersonalDataView();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }
    }
}