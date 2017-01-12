using EppContract;
using HiringCompanyContract;
using HiringCompanyData;
using HiringCompanyService.Access;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.ServiceModel;

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

        public bool AddHiringCompany(HiringCompany company)
        {
            log.Debug("AddHiringCompany Servisni poziv");
            Console.WriteLine("AddHiringCompany...");
            return HiringCompanyDB.Instance.AddCompany(company);
        }

        public HiringCompany GetHiringCompany(int id)
        {
            log.Debug("GetHiringCompany Servisni poziv");
            Console.WriteLine("GetHiringCompany...");
            return HiringCompanyDB.Instance.GetCompany(id);
        }

        public bool AddProjectDefinition(Project project)
        {
            log.Debug("AddProjectDefinition Servisni poziv");
            Console.WriteLine("AddProjectDefinition...");
            return ProjectDB.Instance.AddProject(project);
        }

        public List<Project> GetProjects()
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

       

        public bool RegisterOutsourcingCompany(OutsourcingCompany oc)
        {
            
            bool ret = OCompanyDB.Instance.AddOutsourcingCompany(oc);
            
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

        public bool AcceptPartnership(OutsourcingCompany oc)
        {
            throw new NotImplementedException();
        }

        public List<UserStory> GetUserStoryes(string projectName)
        {
            log.Info("Successfully returned User storyes for defined project name");
            return UserStoryDB.Instance.GetUserStory(projectName);
        }

        public bool AddPartnershipToDB(HiringCompany hc, OutsourcingCompany oc)
        {
            log.Info("AddPartnershipToDB...");
            return PartnershipDB.Instance.AddPartnership(hc, oc);
            
        }

        public List<OutsourcingCompany> GetPartnershipOc(int hiringCompany)
        {
            log.Info("GetPartnershipOc..");
            return PartnershipDB.Instance.GetPartnerOc(hiringCompany);
        }

        public bool AddOutsourcingCompany(OutsourcingCompany oc)
        {
            log.Info("AddOutsourcingCompany...");
            return OCompanyDB.Instance.AddOutsourcingCompany(oc);
        }

        public OutsourcingCompany GetOutsourcingCompany(string name)
        {
            log.Info("GetOutsourcingCompany...");
            return OCompanyDB.Instance.GetOutsourcingCompany(name);
        }

       
    }
}