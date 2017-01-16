using HiringCompanyData;
using HiringCompanyService.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HiringCompanyService
{
    public class Delaying
    {
        public void CheckIfProjectAlmostLate()
        {
            List<Project> currentProjects = new List<Project>(30);
            Employee po = new Employee();
            while (currentProjects.Count != 0)
            {
                foreach (Project proj in currentProjects)
                {
                    if ((proj.Progress <= 80.00) && ((proj.EndDate.Month == DateTime.Now.Month) && ((proj.EndDate.Day - DateTime.Now.Day) <= 10)))
                    {
                        List<Employee> smasteri = EmployeeDB.Instance.GetReallyEmployees();

                        foreach (Employee em in smasteri)
                        {
                            if (em.Position.Equals("SM"))
                            {
                                using (SmtpClient smtpClient = new SmtpClient())
                                {
                                    using (MailMessage message = new MailMessage())
                                    {
                                        message.Subject = "ALARMNO STANJE PROJEKAT NIJE GOTOV!";
                                        message.Body = "Kolega " + em.Name + " " + em.Surname + ", vasi zaposleni NE RADE dobro posao. Slede penali!";
                                        message.To.Add(new MailAddress(em.Email));
                                        try
                                        {
                                            smtpClient.Send(message);
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
                }
            }
        }

        public void CheckIfSomeoneIsLate()
        {
            List<Employee> notSignedInWorkers = new List<Employee>(30);
            List<Employee> workersToSendMail = EmployeeDB.Instance.GetAllNotSignedInEmployees();
            List<Employee> alreadySent = new List<Employee>(30);
            while (!workersToSendMail.Count.Equals(0))
            {
                notSignedInWorkers = EmployeeDB.Instance.GetAllNotSignedInEmployees();
                workersToSendMail = notSignedInWorkers;
                foreach (Employee lateEmp in notSignedInWorkers)
                {
                    if (alreadySent.Contains(lateEmp))
                    {
                        workersToSendMail.Remove(lateEmp);
                    }
                }


                if (!workersToSendMail.Count.Equals(0))
                {
                    foreach (Employee emp in workersToSendMail)
                    {
                        if ((Double.Parse(DateTime.Now.ToString("h.mm")) - Double.Parse(emp.StartTime.ToString())) > 0.15)
                        {
                            String email = EmployeeDB.Instance.GetEmployeeEmail(emp.Username);

                            using (SmtpClient smtpClient = new SmtpClient())
                            {
                                using (MailMessage message = new MailMessage())
                                {
                                    message.Subject = "KASNJENJE!";
                                    message.Body = "Kolega " + emp.Name + " " + emp.Surname + ", KASNITE na posao. Slede penali!";
                                    message.To.Add(new MailAddress(email));
                                    try
                                    {
                                        smtpClient.Send(message);
                                        alreadySent.Add(emp);
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
                notSignedInWorkers.Clear();
            }
        }
    }
}
