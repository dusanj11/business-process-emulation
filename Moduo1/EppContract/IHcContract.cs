using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EppContract
{
    [ServiceContract]
    public interface IHcContract
    {
        // OC poziva metodu da se registruje na servisu HC-a
        [OperationContract]
        bool RegisterOutsourcingCompany(OutsourcingCompany oc);

        // OC poziva metodu da prihvati partnerstvo
        [OperationContract]
        bool AcceptPartnership(OutsourcingCompany oc);

        // OC poziva metodu da dobije US kako bi imali uvid u stanje US 
        // da li su US odobreni ili ne
        [OperationContract]
        List<UserStory> GetUserStoryes(string projectName);

    }
}
