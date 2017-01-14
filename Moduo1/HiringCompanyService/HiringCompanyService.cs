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

        public List<HiringCompanyData.Project> GetProjects(int hiringCompanyId)
        {
            log.Debug("GetProjects Servisni poziv");
            Console.WriteLine("GetProjects...");
            return ProjectDB.Instance.GetProjects(hiringCompanyId);
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


        //public List<HiringCompanyData.UserStory> GetUserStoryes(string projectName)
        //{
        //    log.Info("Successfully returned User storyes for defined project name");
        //    return UserStoryDB.Instance.GetUserStory(projectName);
        //}

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

        public List<HiringCompanyData.OutsourcingCompany> GetOutsourcingCompanies()
        {
            log.Info("GetOutsourcingCompanies...");
            return OCompanyDB.Instance.GetOutsourcingCompanies();
        }

        public List<HiringCompanyData.Project> GetProjectsForHc(int hiringCompanyId)
        {
            log.Info("GetProject for specified hiring company...");
            return ProjectDB.Instance.GetProjects(hiringCompanyId);
        }



        /// <summary>
        ///     INTERFACE IHcContract
        /// </summary>
        public bool RegisterOutsourcingCompany(WcfCommon.Data.OutsourcingCompany oc)
        {

            HiringCompanyData.OutsourcingCompany oc_data = new HiringCompanyData.OutsourcingCompany();
            try
            {
                oc_data.IdFromOutSourcingDB = oc.IdFromOutSourcingDB;
                oc_data.Name = oc.Name;
            }
            catch (Exception e)
            {
                log.Error("Attempt to register outsourcing company that doesn't have Id or Name.");
                return false;
            }
           

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

        public bool AcceptPartnership(WcfCommon.Data.HiringCompany hc, WcfCommon.Data.OutsourcingCompany oc)
        {
            log.Info("AddPartnershipToDB...");
            HiringCompanyData.HiringCompany hc_data = new HiringCompanyData.HiringCompany();
            HiringCompanyData.OutsourcingCompany oc_data = new HiringCompanyData.OutsourcingCompany();

            hc_data = HiringCompanyDB.Instance.GetCompany(hc.IdFromHiringCompanyDB);
            oc_data = OCompanyDB.Instance.GetOutsourcingCompany(oc.Name);
        
            return PartnershipDB.Instance.AddPartnership(hc_data, oc_data);
        }

        public List<WcfCommon.Data.UserStory> GetUserStoryes(string projectName)
        {
            log.Info("Successfully returned User storyes for defined project name");
            List<HiringCompanyData.UserStory> userStories = UserStoryDB.Instance.GetUserStory(projectName);

            List<WcfCommon.Data.UserStory> retval = new List<WcfCommon.Data.UserStory>();



            foreach (HiringCompanyData.UserStory us in userStories)
            {
                WcfCommon.Data.UserStory us_common = new WcfCommon.Data.UserStory();
                us_common.Name = us.Name;
                us_common.Progress = us.Progress;
                //us_common.Project = us.Project;
                us_common.UserStoryState = (WcfCommon.Enums.UserStoryState)us.UserStoryState;
                us_common.WeightOfUserStory = us.WeightOfUserStory;

                retval.Add(us_common);
            }

            return retval;
        }


        /// <summary>
        ///     Method that call ServiceProxy to outsourcing company service
        /// </summary>

        public bool SendPartnershipRequest(int outsourcingCompanyId, HiringCompanyData.HiringCompany hiringCompany)
        {
            WcfCommon.Data.HiringCompany hc_data = new WcfCommon.Data.HiringCompany();

            hc_data.Ceo = hiringCompany.Ceo;
            hc_data.IdFromHiringCompanyDB = hiringCompany.IDHc;
            hc_data.Name = hiringCompany.Name;
           

            bool ret =  ServiceProxy.Instance.SendOcRequest(outsourcingCompanyId, hc_data);

            if (ret)
            {
                log.Info("SUCCESSFULLY SENT PARTNERSHIP REQUEST!");
            }
            else
            {
                log.Warn("Failed to sent partnership request.") ;
            }

            return ret;
        }



        public bool SendProjectRequest(int hiringCompanyID, int outsourcingCompanyId, HiringCompanyData.Project project)
        {
            WcfCommon.Data.Project pr_data = new WcfCommon.Data.Project();

            pr_data.Approved = project.Approved;
            pr_data.Description = project.Description;
            pr_data.EndDate = project.EndDate;
            pr_data.Ended = project.Ended;
            pr_data.Name = project.Name;
            pr_data.Progress = project.Progress;
            pr_data.StartDate = project.StartDate;

            bool ret = ServiceProxy.Instance.SendProject(hiringCompanyID, outsourcingCompanyId, pr_data);

            if (ret)
            {
                log.Info("SUCCESSFULLY SENT PROJECT REQUEST!");
            }
            else
            {
                log.Warn("Failed to sent project request.");
            }

            return ret;
        }

        public bool MarkProjectEnded(HiringCompanyData.Project p)
        {
            log.Info("MarkProjectEnded");
            return ProjectDB.Instance.MarkProjectEnded(p);
        }

        public bool AcceptProject(string projectName, int outsourcingCompanyId)
        {
          
            bool ret = ProjectDB.Instance.SetOcToProject(projectName, outsourcingCompanyId); 

            if (ret)
            {
                log.Info("Outosurcing company accepted project.");
            }
            else
            {
                log.Warn("Failed to accept project.");
            }
            return ret;
        }

        public bool RejectProject(string projectName)
        {
            log.Warn("Outsourcing company rejected project.");
            return true;
        }

        public bool GetOutsourcingCompanyProjects(int hiringCompanyId)
        {
            List<WcfCommon.Data.Project> projects = new List<WcfCommon.Data.Project>();

            try
            {
                projects = ServiceProxy.Instance.GetProjects(hiringCompanyId);
            }
            catch (Exception e)
            {
                log.Error("Can not establish communication with outstoucing companies service.");
                return false;
            }

            foreach( var p in projects)
            {
                HiringCompanyData.Project pr = new HiringCompanyData.Project();
                pr.Approved = p.Approved;
                pr.Description = p.Description;
                pr.EndDate = p.EndDate;
                pr.Ended = p.Ended;
                pr.Name = p.Name;
                pr.Progress = p.Progress;
                pr.EndDate = p.EndDate;

                ProjectDB.Instance.AddProject(pr);
            }

            return true;

        }
    
        public int GetHcIdForUser(string username)
        {
            return EmployeeDB.Instance.GetHcIdForUser(username);
        }

        public bool GetUserStories(string projectName)
        {
            List<WcfCommon.Data.UserStory> userStories_common = new List<WcfCommon.Data.UserStory>();

            try
            {
                userStories_common = ServiceProxy.Instance.GetUserStoryes(projectName);
            }
            catch(Exception e)
            {
                return false;
            }
            

            List<HiringCompanyData.UserStory> userStories = new List<HiringCompanyData.UserStory>();

            foreach (WcfCommon.Data.UserStory u in userStories_common)
            {
                HiringCompanyData.UserStory us = new HiringCompanyData.UserStory();
                us.IdFromOcDB = u.Id;
                us.Description = u.Description;
                us.Name = u.Name;
                us.Progress = u.Progress;
                
                switch(u.UserStoryState)
                {
                    case WcfCommon.Enums.UserStoryState.Approved:
                        {
                            us.UserStoryState = UserStoryState.Approved;
                            break;
                        }

                    case WcfCommon.Enums.UserStoryState.Closed:
                        {
                            us.UserStoryState = UserStoryState.Closed;
                            break;
                        }

                    case WcfCommon.Enums.UserStoryState.Finished:
                        {
                            us.UserStoryState = UserStoryState.Finished;
                            break;
                        }

                    case WcfCommon.Enums.UserStoryState.New:
                        {
                            us.UserStoryState = UserStoryState.New;
                            break;
                        }

                    case WcfCommon.Enums.UserStoryState.Open:
                        {
                            us.UserStoryState = UserStoryState.Open;
                            break;
                        }

                    case WcfCommon.Enums.UserStoryState.Proposed:
                        {
                            us.UserStoryState = UserStoryState.Pending;
                            break;
                        }

                    case WcfCommon.Enums.UserStoryState.Rejected:
                        {
                            us.UserStoryState = UserStoryState.Rejected;
                            break;
                        }
                }

                us.WeightOfUserStory = u.WeightOfUserStory;

                HiringCompanyData.Project p = ProjectDB.Instance.GetProject(projectName);

                us.Project = p;

                UserStoryDB.Instance.AddUserStory(us);

                
            }
            return true;
        }

        public HiringCompanyData.HiringCompany GetHiringCompanyForThr(int thrId)
        {
            return HiringCompanyDB.Instance.GetHiringCompanyFromThr(thrId);
        }
    }
}