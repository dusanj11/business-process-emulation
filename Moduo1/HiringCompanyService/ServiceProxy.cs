using System;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceModel;
using WcfCommon;
using WcfCommon.Data;

namespace HiringCompanyService
{
    public class ServiceProxy : IOcContract, IDisposable
    {
        private static IOcContract proxy;

        private static ChannelFactory<IOcContract> factory;

        private static string address = ConfigurationManager.AppSettings["OutsourcingCompanyServiceAddress"];

        public static IOcContract Instance
        {
            get
            {
                if (proxy == null)
                {
                    NetTcpBinding binding = new NetTcpBinding();
                    binding.OpenTimeout = new TimeSpan(0, 10, 0);
                    binding.CloseTimeout = new TimeSpan(0, 10, 0);
                    binding.ReceiveTimeout = new TimeSpan(0, 10, 0);
                    binding.SendTimeout = new TimeSpan(0, 10, 0);

                    factory = new ChannelFactory<IOcContract>(binding, new EndpointAddress(address));
                    proxy = factory.CreateChannel();

                    IContextChannel cc = proxy as IContextChannel;
                    Console.WriteLine("OC Service state: " + cc.State);
                    State = cc.State;
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

        public static CommunicationState State { get; set; }

        public void Dispose()
        {
            if (factory != null)
            {
                factory = null;
            }
            factory.Close();
        }

        public bool SendOcRequest(int outsourcingCompanyId, WcfCommon.Data.HiringCompany hiringCompany)
        {
            try
            {
                return proxy.SendOcRequest(outsourcingCompanyId, hiringCompany);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: SendOcRequest: \n{0}", e.Message);
                return false;
            }
        }

        public bool SendProject(int hiringCompanyId, int outsourcingCompanyId, WcfCommon.Data.Project project)
        {
            try
            {
                return proxy.SendProject(hiringCompanyId, outsourcingCompanyId, project);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: SendProject: \n{0}", e.Message);
                return false;
            }
        }

        List<WcfCommon.Data.Project> IOcContract.GetProjects(int hiringCompanyId)
        {
            try
            {
                return proxy.GetProjects(hiringCompanyId);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: GetProjects: \n{0}", e.Message);
                return null;
            }
        }

        List<WcfCommon.Data.UserStory> IOcContract.GetUserStoryes(string projectName)
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

        public bool SendUserStory(UserStory userStory)
        {
            try
            {
                return proxy.SendUserStory(userStory);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: GetUserStoryes: \n{0}", e.Message);
                return false;
            }
        }
    }
}