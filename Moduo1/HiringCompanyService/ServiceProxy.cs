using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EppContract;
using System.ServiceModel;
using System.Configuration;
using HiringCompanyData;

namespace HiringCompanyService
{
    public class ServiceProxy : IHcContract, IDisposable
    {

        private static IHcContract proxy;

        private static ChannelFactory<IHcContract> factory;

        private static string address = ConfigurationManager.AppSettings["OutsourcingCompanyServiceAddress"];

        public static IHcContract Instance
        {
            get
            {
                if (proxy == null)
                {
                    factory = new ChannelFactory<IHcContract>(new NetTcpBinding(), new EndpointAddress(address));
                    proxy = factory.CreateChannel();
                }

                return proxy;
            }
            set
            {
                if (proxy == null)
                {
                    proxy = value;
                }
            }
        }


        public void Dispose()
        {
            if (factory != null)
            {
                factory = null;

            }
            factory.Close();
        }

     

        public bool RegisterOutsourcingCompany(OutsourcingCompany oc)
        {
            try
            {
                return proxy.RegisterOutsourcingCompany(oc);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: RegisterOutsourcingCompany: \n{0}", e.Message);
                return false;
            }
        }

        public bool AcceptPartnership(OutsourcingCompany oc)
        {
            try
            {
                return proxy.AcceptPartnership(oc);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: AcceptPartnership: \n{0}", e.Message);
                return false;
            }
        }

        public List<UserStory> GetUserStoryes(string projectName)
        {
            try
            {
                return proxy.GetUserStoryes(projectName);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: GetUserStoryes: \n{0}", e.Message);
                return null;
            }
        }
    }
}
