using Client.ViewModel;
using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Command
{
    public class SaveWorkingHoursCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string username = ClientDialogViewModel.Instance.LogInUser.Username;
            string password = ClientDialogViewModel.Instance.LogInUser.Password;

            string startTime = WorkingHoursViewModel.Instance.StartTime;
            string endTime = WorkingHoursViewModel.Instance.EndTime;

            using (ClientProxy proxy = new ClientProxy(WcfCommon.WcfAttributes.binding, WcfCommon.WcfAttributes.address))
            {
                Employee em = proxy.GetEmployee(username, password);
                if (em != null)
                {
                    em.StartTime = startTime;
                    em.EndTime = endTime;

                    proxy.UpdateEmployee(em);
                }

            }
        }
    }
}
