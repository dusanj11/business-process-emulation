using System;
using System.ServiceModel;
using HiringCompanyContract;
using System.ServiceModel.Description;
using System.Data.Entity;
using HiringCompanyService.Access;


namespace HiringCompanyService
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // set |DataDirectory| in App.config
            string path = System.Environment.CurrentDirectory;
            path = path.Substring(0, path.LastIndexOf("\\"));
            path = path.Substring(0, path.LastIndexOf("\\"));
            //path = path.Substring(0, path.LastIndexOf("bin")) + "Calculator\\DB";
            path += "\\DB";
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
            
            // update database
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AccessDB, Configuration>());

            //DB INITIAL INSERT - test
            //EmployeeDB.Instance.AddAction(new HiringCompanyContract.Data.Employee
            //{
            //    Username = "Miki",
            //    Password = "Dule",
            //    Name = "Dusan",
            //    Surname = "Jeftic",
            //    Position = HiringCompanyContract.Data.Employee.PositionEnum.PO.ToString(),
            //    StartTime = "9",
            //    EndTime = "17",
            //    Login = false,
            //    HiringCompanyId = "HC1",
            //    PasswordUpadateDate = DateTime.Now


            //});
            //EmployeeDB.Instance.AddAction(new HiringCompanyContract.Data.Employee
            //{
            //    Username = "Naci",
            //    Password = "Dule",
            //    Name = "Dusan",
            //    Surname = "Jeftic",
            //    Position = HiringCompanyContract.Data.Employee.PositionEnum.SM.ToString(),
            //    StartTime = "9",
            //    EndTime = "17",
            //    Login = false,
            //    HiringCompanyId = "HC1",
            //    PasswordUpadateDate = DateTime.Now


            //});
            //EmployeeDB.Instance.AddAction(new HiringCompanyContract.Data.Employee
            //{
            //    Username = "Taca",
            //    Password = "Dule",
            //    Name = "Dusan",
            //    Surname = "Jeftic",
            //    Position = HiringCompanyContract.Data.Employee.PositionEnum.HR.ToString(),
            //    StartTime = "9",
            //    EndTime = "17",
            //    Login = false,
            //    HiringCompanyId = "HC1",
            //    PasswordUpadateDate = DateTime.Now


            //});


            NetTcpBinding binding = new NetTcpBinding();
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
