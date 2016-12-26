using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using HiringCompanyContract;
using System.ServiceModel.Description;

namespace HiringCompanyService
{
    class Program
    {
        static void Main(string[] args)
        {

            NetTcpBinding binding = new NetTcpBinding();
            string address = "net.tcp://localhost:9090/HiringCompanyService";


            ServiceHost serviceHost = new ServiceHost(typeof(HiringCompanyService));
            serviceHost.AddServiceEndpoint(typeof(IHiringCompany), binding, address);

            serviceHost.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
            serviceHost.Description.Behaviors.Add(new ServiceDebugBehavior() { IncludeExceptionDetailInFaults = true });


            try
            {
                serviceHost.Open();

                Console.WriteLine("HiringCompany service started.");
                Console.WriteLine("Press <enter> to stop service...");

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("[ERROR] {0}", e.Message);
                Console.WriteLine("[StackTrace] {0}", e.StackTrace);
            }
            finally
            {
                serviceHost.Close();
            }
        }
    }
}
