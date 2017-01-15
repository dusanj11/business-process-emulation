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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            log.Info("Employee sent request to company for a project");
            OutsourcingCompany oc = SendRequestProjectViewModel.Instance.PartnerCompany();

            Project pr = SendRequestProjectViewModel.Instance.Project();


            string username = ClientDialogViewModel.Instance.LogInUser().Username;

            log.Debug("proxy poziv - GetHcIdForUser ");
            int hiringCompanyId = ClientProxy.Instance.GetHcIdForUser(username);
            log.Info("Successfully returned hiring company id.");

            log.Debug("proxy poziv - GetHiringCompany ");
            HiringCompany hc = ClientProxy.Instance.GetHiringCompany(hiringCompanyId);
            log.Info("Successfully returnes hiring company.");

            log.Debug("proxy poziv - SendProjectRequest ");
            ClientProxy.Instance.SendProjectRequest(hc.IDHc, oc.IdFromOutSourcingDB, pr);
            log.Info("Successfully sent request to oc for a project");

        }
    }
}
