using Client.ViewModel;
using HiringCompanyData;
using System;
using System.ServiceModel;
using System.Windows.Input;

namespace Client.Command
{
    public class SavePersonalDataCommand : ICommand
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {
                string name = EditPersonalDataViewModel.Instance.Name();
                string surname = EditPersonalDataViewModel.Instance.Surname();
                string username = EditPersonalDataViewModel.Instance.Username();

                string loginUsername = ClientDialogViewModel.Instance.LogInUser().Username;
                string loginPassword = ClientDialogViewModel.Instance.LogInUser().Password;

                try
                {
                    Employee employee = ClientProxy.Instance.GetEmployee(loginUsername, loginPassword);

                    employee.Name = name;
                    employee.Surname = surname;
                    employee.Username = username;

                    bool ret = ClientProxy.Instance.UpdateEmployee(employee);

                    if (ret)
                    {
                        ClientDialogViewModel.Instance.LogInUser().Username = employee.Username;
                        ClientDialogViewModel.Instance.LogInUser().Password = employee.Password;

                        log.Info("Successfully changed employee personal data.");
                    }
                    else
                    {
                        log.Warn("Failed to change employee personal data.");
                    }
                }
                catch (CommunicationException ce)
                {
                    Console.WriteLine("Error: CommunicationException {0}", ce.Message);
                    log.Error("Communication exception while trying to change employee personal data.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: Exception {0}", e.Message);
                    log.Error("Exception while trying to change employee personal data.");
                }
            }
            catch (Exception e)
            {
                log.Error("Error while trying to create communication proxy.");
            }
        }
    }
}