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
        // HC
        // OC poziva metodu da se registruje na servisu HC-a
        [OperationContract]
        bool RegisterOutsourcingCompany(int value);

        
        [OperationContract]
        List<Project> GetOutsourcingCompanyProjects(string outsourcingCompany);

        // OC poziva metodu automatski kada stigne zahtev za izradu projekta ukoliko 
        // oc prihvati projekat
        [OperationContract]
        Project GetProject(string outsourcingCompany, string project);


        // OC
        // HC poziva metodu da posalje zahtev za partnerstvo
        [OperationContract]
        bool SendOcRequest(string outsourcingCompany);


        [OperationContract]
        bool SendProject(Project project);


        //[OperationContract]
        //List<OutsourcingCompany> GetOutsourcingCompany();

        [OperationContract]
        List<UserStory> GetUserStoryes(string outsourcingCompany, string project);
    }

}
