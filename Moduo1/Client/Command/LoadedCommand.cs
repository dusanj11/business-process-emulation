using HiringCompanyData;
using System;
using System.ServiceModel;
using System.Threading;
using System.Windows.Input;

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
            try
            {
                using (ClientProxy proxy = new ClientProxy(WcfCommon.WcfAttributes.binding, WcfCommon.WcfAttributes.address))
                {
                    int threadId = Thread.CurrentThread.ManagedThreadId;
                    HiringCompany company = new HiringCompany();
                    company.Name = "HC";
                    company.Ceo = "Marko Jelaca";
                    company.CompanyIdThr = threadId;

                    try
                    {
                        proxy.AddHiringCompany(company);
                    }
                    catch (CommunicationException ce)
                    {
                        Console.WriteLine("ERROR >> LoadedCommand communication exception: {0}", ce.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("ERROR >> LoadedCommand inner exception: {0}", e.Message);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Using: {0}", e.Message);
            }
        }
    }
}