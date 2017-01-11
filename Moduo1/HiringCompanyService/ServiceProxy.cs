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
    public class ServiceProxy : IEppContract, IDisposable
    {

        private static IEppContract proxy;

        private static ChannelFactory<IEppContract> factory;

        private static string address = ConfigurationManager.AppSettings["OutsourcingCompanyServiceAddress"];

        public static IEppContract Instance
        {
            get
            {
                if (proxy == null)
                {
                    factory = new ChannelFactory<IEppContract>(new NetTcpBinding(), new EndpointAddress(address));
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

      

        public bool SendOcRequest(string outsourcingCompany)
        {
            try
            {
                return proxy.SendOcRequest(outsourcingCompany);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: GetData: \n{0}", e.Message);
                return false;
            }
        }

        public bool RegisterOutsourcingCompany(int value)
        {
            try
            {
                return proxy.RegisterOutsourcingCompany(value);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: GetData: \n{0}", e.Message);
                return false;
            }
        }

        public List<Project> GetOutsourcingCompanyProjects(string outsourcingCompany)
        {
            throw new NotImplementedException();
        }

        public List<UserStory> GetUserStoryes(string outsourcingCompany, string project)
        {
            throw new NotImplementedException();
        }

        bool IEppContract.RegisterOutsourcingCompany(int value)
        {
            throw new NotImplementedException();
        }

        public Project GetProject(string outsourcingCompany, string project)
        {
            throw new NotImplementedException();
        }

        public bool SendProject(Project project)
        {
            throw new NotImplementedException();
        }
    }
}
