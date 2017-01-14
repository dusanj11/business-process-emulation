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
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OutsourcingCompany oc = SendRequestCompanyViewModel.Instance.Company();

            string username = ClientDialogViewModel.Instance.LogInUser().Username;

            int hiringCompanyId = ClientProxy.Instance.GetHcIdForUser(username);

            HiringCompany hc = ClientProxy.Instance.GetHiringCompany(hiringCompanyId);

            ClientProxy.Instance.SendPartnershipRequest(oc.IdFromOutSourcingDB, hc);

        }
    }
}
