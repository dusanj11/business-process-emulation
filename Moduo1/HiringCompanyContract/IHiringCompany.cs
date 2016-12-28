using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HiringCompanyContract
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IHiringCompany
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        List<Data.Employee> GetAllEmployees();
        // TODO: Add your service operations here
    }
}
