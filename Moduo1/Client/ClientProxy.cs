using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiringCompanyContract;
using System.ServiceModel;
using HiringCompanyContract.Data;

namespace Client
{
    public class ClientProxy : ChannelFactory<IHiringCompany>, IHiringCompany, IDisposable
    {
        IHiringCompany factory;

        public ClientProxy(NetTcpBinding binding, string address) : base(binding, address)
        {
            factory = this.CreateChannel();
        }

        public void Dispose()
        {
            if (factory != null)
            {
                factory = null;

            }
            this.Close();
        }

        /// <summary>
        ///     Test method
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetData(int value)
        {
           return factory.GetData(5);
        }

        public List<Employee> GetAllEmployees()
        {
            return (List<Employee>)factory.GetAllEmployees();
        }

      
    }
}
