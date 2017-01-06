using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Input;
using HiringCompanyData;

namespace Client.Command
{
    public class LoadedCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            
            using (ClientProxy proxy = new ClientProxy(WcfCommon.WcfAttributes.binding, WcfCommon.WcfAttributes.address))
            {
                int threadId = Thread.CurrentThread.ManagedThreadId;
                HiringCompany company = new HiringCompany();
                company.Name = "HC";
                company.Ceo = "Marko Jelaca";
                company.CompanyIdThr = threadId;

                proxy.AddHiringCompany(company);
            }
        }
    }
}
