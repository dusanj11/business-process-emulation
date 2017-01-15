﻿using System;
using System.ServiceModel;
using HiringCompanyContract;
using System.ServiceModel.Description;
using System.Data.Entity;
using HiringCompanyService.Access;
using System.Threading;
using HiringCompanyData;
using System.Net.Mail;
using System.Collections.Generic;
using WcfCommon;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace HiringCompanyService
{
    public class Program
    {

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Main(string[] args)
        {

            Log.Debug("Start Program.cs HiringCompanyService.");

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


            NetTcpBinding binding = new NetTcpBinding();
            binding.OpenTimeout = new TimeSpan(0, 10, 0);
            binding.CloseTimeout = new TimeSpan(0, 10, 0);
            binding.ReceiveTimeout = new TimeSpan(0, 10, 0);
            binding.SendTimeout = new TimeSpan(0, 10, 0);
           
            string address = "net.tcp://localhost:9090/HiringCompanyService";
          

            ServiceHost serviceHost = new ServiceHost(typeof(HiringCompanyService));
            serviceHost.AddServiceEndpoint(typeof(IHiringCompany), binding, address);
            serviceHost.AddServiceEndpoint(typeof(IHcContract), binding, address);

            serviceHost.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
            serviceHost.Description.Behaviors.Add(new ServiceDebugBehavior() { IncludeExceptionDetailInFaults = true });


            try
            {
                serviceHost.Open();


                Log.Info("HiringCompany service started.");
                Log.Info("Press <enter> to stop service...");
                //Delaying del = new Delaying();
                //if (5 <= DateTime.Now.Hour && DateTime.Now.Hour <= 24)
                //{
                //    Thread checkThread = new Thread(new ThreadStart(del.CheckIfSomeoneIsLate));
                //    checkThread.Start();
                //}
                //Thread alarmPo = new Thread(new ThreadStart(del.CheckIfProjectAlmostLate));
                //alarmPo.Start();
                    
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
            Employee po = new Employee();
            while (currentProjects.Count != 0)
            {
                foreach (Project proj in currentProjects)
                {
                    if ((proj.Progress <= 8.00) && ((proj.EndDate.Month == DateTime.Now.Month) && ((proj.EndDate.Day - DateTime.Now.Day) <= 10)))
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
