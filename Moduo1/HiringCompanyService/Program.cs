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

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace HiringCompanyService
{
    public class Program
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Main(string[] args)
        {

            log.Debug("Start Program.cs HiringCompanyService.");

            // set |DataDirectory| in App.config
            string path = System.Environment.CurrentDirectory;
            Console.WriteLine(path);
            path = path.Substring(0, path.LastIndexOf("\\"));
            path = path.Substring(0, path.LastIndexOf("\\"));

            string logPath = path + "\\Log\\HiringCompanyLog.txt";

            path += "\\DB";
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            AppDomain.CurrentDomain.SetData("LogDirectory", logPath);

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
            //    Email = "jelaca.marko@gmail.com",
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
            //    Email = "dusan.jeftic11@gmail.com",
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


                log.Info("HiringCompany service started.");
                log.Info("Press <enter> to stop service...");
                //Delaying del = new Delaying();
                //if (5 <= DateTime.Now.Hour && DateTime.Now.Hour <= 24)
                //{
                //    Thread checkThread = new Thread(new ThreadStart(del.CheckIfSomeoneIsLate));
                //    checkThread.Start();
                //}
                    

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
    }

    public class Delaying
    {
        public void CheckIfProjectAlmostLate()
        {
            List<Project> currentProjects = new List<Project>(30);

            while(currentProjects.Count != 0)
            {
                foreach(Project proj in currentProjects)
                {

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
                        if ((Double.Parse((DateTime.Now.ToString("h.mm"))) - Double.Parse(emp.StartTime.ToString())) > 0.15)
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
