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

            HiringCompany hc = ClientProxy.Instance.GetHiringCompany(Thread.CurrentThread.ManagedThreadId);


            ClientProxy.Instance.SendProjectRequest(hc.IDHc, oc.IdFromOutSourcingDB, pr);

        }
    }
}
