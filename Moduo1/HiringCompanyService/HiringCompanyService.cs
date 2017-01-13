using HiringCompanyContract;
using HiringCompanyData;
using HiringCompanyService.Access;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.ServiceModel;
using WcfCommon;
using WcfCommon.Data;

namespace HiringCompanyService
{
    public class HiringCompanyService : IHiringCompany, IHcContract
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

   

        public List<Employee> GetAllEmployees()
        {
            Console.WriteLine("GetAllEmployees...");
            return EmployeeDB.Instance.GetEmployees();
        }

        public List<Employee> GetAllNotSignedInEmployees()
        {
            Console.WriteLine("GetAllNotSignedInEmployees...");
            return EmployeeDB.Instance.GetAllNotSignedInEmployees();
        }

        public Employee GetEmployee(string username, string password)
        {
            Console.WriteLine("GetEmployee...");
            return EmployeeDB.Instance.GetEmployee(username, password);
        }

        public bool AddEmployee(Employee employee)
        {
            log.Info("AddEmployee...");
            return EmployeeDB.Instance.AddEmployee(employee);
        }

        public bool ChangeEmployeePosition(string username, string position)
        {
            Console.WriteLine("ChangeEmployeePostition...");
            return EmployeeDB.Instance.ChangeEmployeePosition(username, position);
        }

        public bool UpdateEmployee(Employee employee)
        {
            Console.WriteLine("UpdateEmployee...");
            return EmployeeDB.Instance.UpdateEmployee(employee);
        }

        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            Console.WriteLine("ChangePassword...");
            return EmployeeDB.Instance.ChangeEmployeePassword(username, oldPassword, newPassword);
        }

        public bool EmployeeLogIn(string username)
        {
            IContextChannel cc = OperationContext.Current.Channel;
            cc.Faulted += Cc_Faulted;
            cc.Opened += Cc_Opened;

            Console.WriteLine("EmployeeLogIn...");
            return EmployeeDB.Instance.EmployeeLogIn(username);
        }

        private void Cc_Opened(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Cc_Faulted(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public bool EmployeeLogOut(string username)
        {
            Console.WriteLine("EmployeeLogOut...");
            return EmployeeDB.Instance.EmployeeLogOut(username);
        }

        public bool AddHiringCompany(HiringCompanyData.HiringCompany company)
        {
            log.Debug("AddHiringCompany Servisni poziv");
            Console.WriteLine("AddHiringCompany...");
            return HiringCompanyDB.Instance.AddCompany(company);
        }

        public HiringCompanyData.HiringCompany GetHiringCompany(int id)
        {
            log.Debug("GetHiringCompany Servisni poziv");
            Console.WriteLine("GetHiringCompany...");
            return HiringCompanyDB.Instance.GetCompany(id);
        }

        public bool AddProjectDefinition(HiringCompanyData.Project project)
        {
            log.Debug("AddProjectDefinition Servisni poziv");
            Console.WriteLine("AddProjectDefinition...");
            return ProjectDB.Instance.AddProject(project);
        }

        public List<HiringCompanyData.Project> GetProjects()
        {
            log.Debug("GetProjects Servisni poziv");
            Console.WriteLine("GetProjects...");
            return ProjectDB.Instance.GetProjects();
        }

        public bool SendDelayingEmail(string username)
        {
            Console.WriteLine("SendEmailsEmployees...");
            String email = EmployeeDB.Instance.GetEmployeeEmail(username);

            using (SmtpClient smtpClient = new SmtpClient())
            {

                using (MailMessage message = new MailMessage())
                {
                    message.Subject = "KASNJENJE!";
                    message.Body = "Kolega " + username + ", KASNITE na posao. Slede penali!";
                    message.To.Add(new MailAddress(email));
                    try
                    {
                        smtpClient.Send(message);
                        return true;
                    }
                    catch (Exception exc)
                    {
                        throw new FaultException(exc.Message);
                    }
                }
            }
        }

      

        public List<Employee> GetReallyAllEmployees()
        {
            Console.WriteLine("GetReallyAllEmployees...");
            return EmployeeDB.Instance.GetReallyEmployees();
        }


        public bool AcceptPartnership(HiringCompanyData.OutsourcingCompany oc)
        {
            throw new NotImplementedException();
        }

        public List<HiringCompanyData.UserStory> GetUserStoryes(string projectName)
        {
            log.Info("Successfully returned User storyes for defined project name");
            return UserStoryDB.Instance.GetUserStory(projectName);
        }

        public bool AddPartnershipToDB(HiringCompanyData.HiringCompany hc, HiringCompanyData.OutsourcingCompany oc)
        {
            log.Info("AddPartnershipToDB...");
            return PartnershipDB.Instance.AddPartnership(hc, oc);
            
        }

        public List<HiringCompanyData.OutsourcingCompany> GetPartnershipOc(int hiringCompany)
        {
            log.Info("GetPartnershipOc..");
            return PartnershipDB.Instance.GetPartnerOc(hiringCompany);
        }

        public bool AddOutsourcingCompany(HiringCompanyData.OutsourcingCompany oc)
        {
            log.Info("AddOutsourcingCompany...");
            return OCompanyDB.Instance.AddOutsourcingCompany(oc);
        }

        public Object GetOutsourcingCompany(string name)
        {
            log.Info("GetOutsourcingCompany...");
            return OCompanyDB.Instance.GetOutsourcingCompany(name);
        }

        public HiringCompanyData.Project GetProject(string projectName)
        {
            log.Info("GetProject...");
            return ProjectDB.Instance.GetProject(projectName);
        }

        public bool AddUserStory(HiringCompanyData.UserStory us)
        {
            log.Info("AddUserStory...");
            return UserStoryDB.Instance.AddUserStory(us);
        }

        public List<HiringCompanyData.Project> GetPartnershipProjects(int hiringCompanyTr)
        {
            log.Info("GetPartnershipProjects...");
            return PartnershipDB.Instance.GetPartnershipProjects(hiringCompanyTr);
        }

        public bool ChangeUserStoryState(int id, UserStoryState state)
        {
            log.Info("ChangeUserStoryState...");
            return UserStoryDB.Instance.ChangeUserStoryState(id, state);
        }

        public List<HiringCompanyData.UserStory> GetProjectUserStory(string projectName)
        {
            log.Info("GetProjectUserStory...");
            return ProjectDB.Instance.GetProjectUserStory(projectName);
        }

        public List<HiringCompanyData.UserStory> GetProjectPendingUserStory(string projectName)
        {
            log.Info("GetProjectPendingUserStory...");
            return ProjectDB.Instance.GetProjectPendingUserStory(projectName);
        }

        HiringCompanyData.OutsourcingCompany IHiringCompany.GetOutsourcingCompany(string name)
        {
            log.Info("GetOutsourcingCompany...");
            return OCompanyDB.Instance.GetOutsourcingCompany(name);
        }

        /// <summary>
        ///     INTERFACE IOcContract
        /// </summary>
        public bool RegisterOutsourcingCompany(WcfCommon.Data.OutsourcingCompany oc)
        {

            HiringCompanyData.OutsourcingCompany oc_data = new HiringCompanyData.OutsourcingCompany();
            oc_data.IdFromOutSourcingDB = oc.Id;
            oc_data.Name = oc.Name;
           

            bool ret = OCompanyDB.Instance.AddOutsourcingCompany(oc_data);

            if (ret)
            {
                log.Info("Successfully added Outsourcing company to DB");
            }
            else
            {
                log.Warn("Failed to add Outsourcing company to DB");
            }

            return ret;
        }

        public bool AcceptPartnership(WcfCommon.Data.OutsourcingCompany oc)
        {
            throw new NotImplementedException();
        }

        List<WcfCommon.Data.UserStory> IHcContract.GetUserStoryes(string projectName)
        {
            throw new NotImplementedException();
        }

        
    }
}