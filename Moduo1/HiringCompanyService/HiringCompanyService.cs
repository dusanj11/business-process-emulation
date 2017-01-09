using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using HiringCompanyContract;
using HiringCompanyService.Access;
using HiringCompanyData;
using System.Net.Mail;

namespace HiringCompanyService
{
    public class HiringCompanyService : IHiringCompany
    {


        public List<Employee> GetAllEmployees()
        {
            Console.WriteLine("GetAllEmployees...");
            return EmployeeDB.Instance.GetEmployees();      
        }

        public Employee GetEmployee(string username, string password)
        {
            Console.WriteLine("GetEmployee...");
            return EmployeeDB.Instance.GetEmployee(username, password);
        }

        public bool AddEmployee(Employee employee)
        {
            Console.WriteLine("AddEmployee...");
            return EmployeeDB.Instance.AddEmployee(employee);
        }

        public bool ChangeEmployeePostition(string username, PositionEnum position)
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
            Console.WriteLine("EmployeeLogIn...");
            return EmployeeDB.Instance.EmployeeLogIn(username);
        }

        public bool EmployeeLogOut(string username)
        {
            Console.WriteLine("EmployeeLogOut...");
            return EmployeeDB.Instance.EmployeeLogOut(username);
        }

        public bool AddHiringCompany(HiringCompany company)
        {
            Console.WriteLine("AddHiringCompany...");
            return HiringCompanyDB.Instance.AddCompany(company);
        }

        public HiringCompany GetHiringCompany(int id)
        {
            Console.WriteLine("GetHiringCompany...");
            return HiringCompanyDB.Instance.GetCompany(id);
        }

        public bool AddProjectDefinition(Project project)
        {
            Console.WriteLine("AddProjectDefinition...");
            return ProjectDB.Instance.AddProject(project);
        }

        public List<Project> GetProjects()
        {
            Console.WriteLine("GetProjects...");
            return ProjectDB.Instance.GetProjects();
        }
        public bool SendDelayingEmail(string username)
        {
            String email = EmployeeDB.Instance.GetEmployeeEmail(username);

            using(SmtpClient smtpClient = new SmtpClient())
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
    }
}
