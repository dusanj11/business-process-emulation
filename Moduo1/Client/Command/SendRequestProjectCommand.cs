using Client.ViewModel;
using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Command
{
    public class SendRequestProjectCommand : ICommand
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Log.Info("Employee sent request to company for a project");
            OutsourcingCompany oc = SendRequestProjectViewModel.Instance.PartnerCompany();

            Project pr = SendRequestProjectViewModel.Instance.Project();


            string username = ClientDialogViewModel.Instance.LogInUser().Username;

            Log.Debug("proxy poziv - GetHcIdForUser ");
            int hiringCompanyId = ClientProxy.Instance.GetHcIdForUser(username);
            Log.Info("Successfully returned hiring company id.");

            Log.Debug("proxy poziv - GetHiringCompany ");
            HiringCompany hc = ClientProxy.Instance.GetHiringCompany(hiringCompanyId);
            Log.Info("Successfully returnes hiring company.");

            Log.Debug("proxy poziv - SendProjectRequest ");
            ClientProxy.Instance.SendProjectRequest(hc.IDHc, oc.IdFromOutSourcingDB, pr);
            Log.Info("Successfully sent request to oc for a project");

        }
    }
}
