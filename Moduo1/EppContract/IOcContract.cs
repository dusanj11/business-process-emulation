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
    public interface IOcContract
    {
        // HC poziva metodu da posalje zahtev za partnerstvo
        [OperationContract]
        bool SendOcRequest(int outsourcingCompanyIdFromDB, HiringCompany hiringCompany);

        // HC poziva metodu da posalje projekat 
        [OperationContract]
        bool SendProject(Project project);

        // HC poziva metodu da dobije projekte
        [OperationContract]
        List<Project> GetProjects();

        // HC poziva metodu da dobije US odgovarajuce OC i projekta koji realizuje 
        [OperationContract]
        List<UserStory> GetUserStoryes(int outsourcingCompanyIdFromDB, string projectName);
    }
}
