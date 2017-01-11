using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EppContract
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IEppContract
    {
        [OperationContract]
        string RegisterOutsourcingCompany(int value);

        [OperationContract]
        bool SendOcRequest(string outsourcingCompany);

        [OperationContract]
        List<Project> GetOutsourcingCompanyProjects(string outsourcingCompany);

        //[OperationContract]
        //List<OutsourcingCompany> GetOutsourcingCompany();

        [OperationContract]
        List<UserStory> GetUserStoryes(string outsourcingCompany, string project);
    }

}
