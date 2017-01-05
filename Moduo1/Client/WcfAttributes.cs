using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WcfCommon
{
    public static class WcfAttributes
    {
        /// <summary>
        ///     WCF binding and address for communication with service
        /// </summary>
        public static NetTcpBinding binding = new NetTcpBinding();
        public static string address = "net.tcp://localhost:9090/HiringCompanyService";
    }
}
