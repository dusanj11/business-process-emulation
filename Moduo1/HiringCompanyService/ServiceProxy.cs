using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EppContract;
using System.ServiceModel;

namespace HiringCompanyService
{
    public class ServiceProxy : ChannelFactory<IEppContract>, IEppContract, IDisposable
    {

        private IEppContract factory;

        public ServiceProxy(NetTcpBinding binding, string address) : base(binding, address)
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

        public string GetData(int value)
        {
            return factory.GetData(value);
        }
    }
}
