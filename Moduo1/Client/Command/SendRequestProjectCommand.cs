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
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OutsourcingCompany oc = SendRequestProjectViewModel.Instance.PartnerCompany();

            Project pr = SendRequestProjectViewModel.Instance.Project();


            string username = ClientDialogViewModel.Instance.LogInUser().Username;

            int hiringCompanyId = ClientProxy.Instance.GetHcIdForUser(username);

            HiringCompany hc = ClientProxy.Instance.GetHiringCompany(hiringCompanyId);


            ClientProxy.Instance.SendProjectRequest(hc.IDHc, oc.IdFromOutSourcingDB, pr);

        }
    }
}
