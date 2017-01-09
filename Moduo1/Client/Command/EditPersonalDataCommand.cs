using Client.ViewModel;
using HiringCompanyData;
using System;
using System.ServiceModel;
using System.Windows.Input;
using WcfCommon;

namespace Client.Command
{
    public class EditPersonalDataCommand : ICommand
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {

            try
            {
                string username = ClientDialogViewModel.Instance.LogInUser.Username;
                string password = ClientDialogViewModel.Instance.LogInUser.Password;

                Employee employeeFromDB;

                using (ClientProxy proxy = new ClientProxy(WcfAttributes.binding, WcfAttributes.address))
                {
                    try
                    {
                        employeeFromDB = proxy.GetEmployee(username, password);

                        EditPersonalDataViewModel.Instance.Name = employeeFromDB.Name;
                        EditPersonalDataViewModel.Instance.Surname = employeeFromDB.Surname;
                        EditPersonalDataViewModel.Instance.Username = employeeFromDB.Username;

                        log.Info("Successfully returned employee personal data.");
                    }
                    catch (CommunicationException ce)
                    {
                        Console.WriteLine("Error: CommunicationException {0}", ce.Message);
                        log.Error("Communication Exception while trying to return employee personal data.");
                    }
                    catch (Exception e)
                    {
                        log.Error("Exception while trying to return employee personal data.");
                        Console.WriteLine("Error: {0}", e.Message);
                    }
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