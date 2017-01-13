using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HiringCompanyData;

namespace HiringCompanyContract
{
    
    [ServiceContract]
    public interface IHiringCompany
    {
       
        [OperationContract]
        List<Employee> GetAllEmployees();

        [OperationContract]
        List<Employee> GetAllNotSignedInEmployees();

        [OperationContract]
        List<Employee> GetReallyAllEmployees();

        [OperationContract]
        Employee GetEmployee(string username, string password);

        [OperationContract]
        bool AddEmployee(Employee employee);

        [OperationContract]
        bool ChangeEmployeePosition(string username, string position);

        [OperationContract]
        bool UpdateEmployee(Employee employee);

        [OperationContract]
        bool ChangePassword(string username, string oldPassword, string newPassword);

        [OperationContract]
        bool EmployeeLogIn(string username);

        [OperationContract]
        bool EmployeeLogOut(string username);

        [OperationContract]
        bool AddHiringCompany(HiringCompany company);

        [OperationContract]
        HiringCompany GetHiringCompany(int id);

        [OperationContract]
        bool AddProjectDefinition(Project project);

        [OperationContract]
        List<Project> GetProjects();

        [OperationContract]
        bool SendDelayingEmail(string username);

        [OperationContract]
        Project GetProject(string projectName);

        [OperationContract]
        bool AddUserStory(UserStory us);

        [OperationContract]
        List<Project> GetPartnershipProjects(int hiringCompanyTr);

        [OperationContract]
        bool ChangeUserStoryState(int id, UserStoryState state);

        [OperationContract]
        List<UserStory> GetProjectUserStory(string projectName);

        [OperationContract]
        List<UserStory> GetProjectPendingUserStory(string projectName);

        [OperationContract]
        List<OutsourcingCompany> GetOutsourcingCompanies();

        [OperationContract]
        bool SendPartnershipRequest(int outsourcingCompanyId, HiringCompany hiringCompany);

        [OperationContract]
        bool SendProjectRequest(int hiringCompanyID, int outsourcingCompanyId, Project project);

        [OperationContract]
        List<Project> GetProjectsForHc(int hiringCompanyId);

        [OperationContract]
        bool MarkProjectEnded(Project p);

        /// ************************************** TEST ************************************** 

        [OperationContract]
        bool AddPartnershipToDB(HiringCompany hc, HiringCompanyData.OutsourcingCompany oc);

        [OperationContract]
        List<HiringCompanyData.OutsourcingCompany> GetPartnershipOc(int hiringCompany);

        [OperationContract]
        bool AddOutsourcingCompany(HiringCompanyData.OutsourcingCompany oc);

        [OperationContract]
        OutsourcingCompany GetOutsourcingCompany(string name);
    }
}
