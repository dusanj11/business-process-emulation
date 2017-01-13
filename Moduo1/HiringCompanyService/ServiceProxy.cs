using System;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceModel;
using WcfCommon;

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
                    factory = new ChannelFactory<IOcContract>(new NetTcpBinding(), new EndpointAddress(address));
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

        public bool SendProject(WcfCommon.Data.Project project)
        {
            try
            {
                return proxy.SendProject(project);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: SendProject: \n{0}", e.Message);
                return false;
            }
        }

        List<WcfCommon.Data.Project> IOcContract.GetProjects()
        {
            try
            {
                return proxy.GetProjects();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: GetProjects: \n{0}", e.Message);
                return null;
            }
        }

        List<WcfCommon.Data.UserStory> IOcContract.GetUserStoryes(int outsourcingCompanyIdFromDB, string projectName)
        {
            try
            {
                return proxy.GetUserStoryes(outsourcingCompanyIdFromDB, projectName);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: GetUserStoryes: \n{0}", e.Message);
                return null;
            }
        }
    }
}