using System;
using System.ServiceModel;
using HiringCompanyContract;
using System.ServiceModel.Description;
using System.Data.Entity;
using HiringCompanyService.Access;
using System.Threading;
using HiringCompanyData;
using System.Net.Mail;
using System.Collections.Generic;

namespace HiringCompanyService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            // set |DataDirectory| in App.config
            string path = System.Environment.CurrentDirectory;
            path = path.Substring(0, path.LastIndexOf("\\"));
            path = path.Substring(0, path.LastIndexOf("\\"));
            path += "\\DB";
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
            
            // update database
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AccessDB, Configuration>());

            //EmployeeDB.Instance.AddEmployee(new Employee
            //{
            //    Name = "Marko",
            //    Surname = "Jelaca",
            //    Username = "maki",
            //    Password = "maki",
            //    Position = PositionEnum.HR.ToString(),
            //    StartTime = "10.00",
            //    EndTime = "17.00",
            //    Login = false,
            //    PasswordUpadateDate = DateTime.Now,
            //    HiringCompanyId = HiringCompanyDB.Instance.GetCompany(Thread.CurrentThread.ManagedThreadId)

            //});

            //EmployeeDB.Instance.AddEmployee(new Employee
            //{
            //    Name = "Dusan",
            //    Surname = "Jeftic",
            //    Username = "dule",
            //    Password = "dule",
            //    Position = PositionEnum.CEO.ToString(),
            //    StartTime = "09.00",
            //    EndTime = "16.00",
            //    Login = false,
            //    PasswordUpadateDate = DateTime.Now,
            //    HiringCompanyId = HiringCompanyDB.Instance.GetCompany(Thread.CurrentThread.ManagedThreadId)

            //});

            //EmployeeDB.Instance.AddEmployee(new Employee
            //{
            //    Name = "Natasa",
            //    Surname = "Subic",
            //    Username = "naci",
            //    Password = "naci",
            //    Position = PositionEnum.SM.ToString(),
            //    StartTime = "10.00",
            //    EndTime = "17.00",
            //    Login = false,
            //    PasswordUpadateDate = DateTime.Now,
            //    HiringCompanyId = HiringCompanyDB.Instance.GetCompany(Thread.CurrentThread.ManagedThreadId)

            //});

            //EmployeeDB.Instance.AddEmployee(new Employee
            //{
            //    Name = "Milica",
            //    Surname = "Kapetina",
            //    Username = "mici",
            //    Password = "mici",
            //    Position = PositionEnum.PO.ToString(),
            //    StartTime = "09.00",
            //    EndTime = "16.00",
            //    Login = false,
            //    PasswordUpadateDate = DateTime.Now,
            //    HiringCompanyId = HiringCompanyDB.Instance.GetCompany(Thread.CurrentThread.ManagedThreadId)

            //});

            NetTcpBinding binding = new NetTcpBinding();
            binding.OpenTimeout = new TimeSpan(0, 10, 0);
            binding.CloseTimeout = new TimeSpan(0, 10, 0);
            binding.ReceiveTimeout = new TimeSpan(0, 10, 0);
            binding.SendTimeout = new TimeSpan(0, 10, 0);
           
            string address = "net.tcp://localhost:9090/HiringCompanyService";
          

            ServiceHost serviceHost = new ServiceHost(typeof(HiringCompanyService));
            serviceHost.AddServiceEndpoint(typeof(IHiringCompany), binding, address);

            serviceHost.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
            serviceHost.Description.Behaviors.Add(new ServiceDebugBehavior() { IncludeExceptionDetailInFaults = true });


            try
            {
                serviceHost.Open();

                Console.WriteLine("HiringCompany service started.");
                Console.WriteLine("Press <enter> to stop service...");

                if (13 <= DateTime.Now.Hour && DateTime.Now.Hour <= 14)
                    CheckIfSomeoneIsLate();

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("[ERROR] {0}", e.Message);
                Console.WriteLine("[StackTrace] {0}", e.StackTrace);
            }
            finally
            {
                serviceHost.Close();
            }
        }

        public static void CheckIfSomeoneIsLate()
        {
            List<Employee> notSignedInWorkers = new List<Employee>(30);
            List<Employee> workersToSendMail = EmployeeDB.Instance.GetAllNotSignedInEmployees();
            List<Employee> alreadySent = new List<Employee>(30);
            while ((13 <= DateTime.Now.Hour && DateTime.Now.Hour <= 14) && workersToSendMail.Count.Equals(0))
            {
                notSignedInWorkers = EmployeeDB.Instance.GetAllNotSignedInEmployees();
                workersToSendMail = notSignedInWorkers;
                foreach(Employee  lateEmp in notSignedInWorkers)
                {
                    if(alreadySent.Contains(lateEmp))
                    {
                        workersToSendMail.Remove(lateEmp);
                    }
                }

                
                if (!workersToSendMail.Count.Equals(0))
                {
                    foreach (Employee emp in workersToSendMail)
                    {
                        if (Double.Parse(emp.StartTime.ToString()) < Double.Parse((DateTime.Now.ToString("h.mm"))))
                        {
                            if (!alreadySent.Contains(emp))
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
                }
                notSignedInWorkers.Clear();
            }
        }
    }
}
