using System;
using System.ServiceModel;
using HiringCompanyContract;
using System.ServiceModel.Description;
using System.Data.Entity;
using HiringCompanyService.Access;
using System.Threading;
using HiringCompanyData;

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
            //    Position = PositionEnum.CEO.ToString(),
            //    StartTime = "10.00",
            //    EndTime = "17.00",
            //    Login = false,
            //    PasswordUpadateDate = DateTime.Now,
            //    HiringCompanyId = HiringCompanyDB.Instance.GetCompany(Thread.CurrentThread.ManagedThreadId)

            //});

            NetTcpBinding binding = new NetTcpBinding();
            binding.OpenTimeout = new TimeSpan(0, 10, 0);
            binding.CloseTimeout = new TimeSpan(0, 10, 0);
            binding.ReceiveTimeout = new TimeSpan(0, 10, 0);
            binding.SendTimeout = new TimeSpan(0, 10, 0);
           
            string address = "net.tcp://192.168.1.24:9090/HiringCompanyService";
          

            ServiceHost serviceHost = new ServiceHost(typeof(HiringCompanyService));
            serviceHost.AddServiceEndpoint(typeof(IHiringCompany), binding, address);

            serviceHost.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
            serviceHost.Description.Behaviors.Add(new ServiceDebugBehavior() { IncludeExceptionDetailInFaults = true });


            try
            {
                serviceHost.Open();

                Console.WriteLine("HiringCompany service started.");
                Console.WriteLine("Press <enter> to stop service...");

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
