using Client.ViewModel;
using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Input;

namespace Client.Command
{
    public class SendRequestCompanyCommand : ICommand
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            log.Info("Employee sent request for partnership.");
            OutsourcingCompany oc = SendRequestCompanyViewModel.Instance.Company();

            string username = ClientDialogViewModel.Instance.LogInUser().Username;

            log.Debug("proxy poziv - GetHcIdForUser");
            int hiringCompanyId = ClientProxy.Instance.GetHcIdForUser(username);
            log.Info("Successfully returner hiring company id.");

            log.Debug("proxy poziv - GetHiringCompany");
            HiringCompany hc = ClientProxy.Instance.GetHiringCompany(hiringCompanyId);
            log.Info("Successfully returned hiring company.");

            log.Debug("proxy poziv - SendPartnershipRequest");
            ClientProxy.Instance.SendPartnershipRequest(oc.IdFromOutSourcingDB, hc);
            log.Info("Successfully sent partnership request.");


        }
    }
}
