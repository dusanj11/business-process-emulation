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
}
