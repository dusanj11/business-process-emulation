using HiringCompanyData;
using HiringCompanyService.Access;
using System;
using System.ServiceModel;
using System.Threading;
using System.Windows.Input;

namespace Client.Command
{
    public class LoadedCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {
                using (ClientProxy proxy = new ClientProxy(WcfCommon.WcfAttributes.binding, WcfCommon.WcfAttributes.address))
                {
                    int threadId = Thread.CurrentThread.ManagedThreadId;
                    HiringCompany company = new HiringCompany();
                    company.Name = "HC";
                    company.Ceo = "Marko Jelaca";
                    company.CompanyIdThr = threadId;

                    try
                    {
                        proxy.AddHiringCompany(company);

                        HiringCompany hc = proxy.GetHiringCompany(threadId);

                        Employee testEmp = new Employee();
                        testEmp.Name = "Marko";
                        testEmp.Surname = "Jelaca";
                        testEmp.Username = "maki";
                        testEmp.Password = "maki";
                        testEmp.Position = PositionEnum.PO.ToString();
                        testEmp.StartTime = "10.00";
                        testEmp.EndTime = "17.00";
                        testEmp.Login = false;
                        testEmp.PasswordUpadateDate = DateTime.Now;
                        testEmp.HiringCompanyId = hc;

                        proxy.AddEmployee(testEmp);


                    }
                    catch (CommunicationException ce)
                    {
                        Console.WriteLine("ERROR >> LoadedCommand communication exception: {0}", ce.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("ERROR >> LoadedCommand inner exception: {0}", e.Message);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Using: {0}", e.Message);
            }


            EmployeeDB.Instance.AddEmployee(new Employee
            {
                Name = "Marko",
                Surname = "Jelaca",
                Username = "maki",
                Password = "maki",
                Position = PositionEnum.HR.ToString(),
                StartTime = "10.00",
                EndTime = "17.00",
                Login = false,
                PasswordUpadateDate = DateTime.Now,
                HiringCompanyId = HiringCompanyDB.Instance.GetCompany(Thread.CurrentThread.ManagedThreadId)

            });

            EmployeeDB.Instance.AddEmployee(new Employee
            {
                Name = "Dusan",
                Surname = "Jeftic",
                Username = "dule",
                Password = "dule",
                Position = PositionEnum.CEO.ToString(),
                StartTime = "09.00",
                EndTime = "16.00",
                Login = false,
                PasswordUpadateDate = DateTime.Now,
                HiringCompanyId = HiringCompanyDB.Instance.GetCompany(Thread.CurrentThread.ManagedThreadId)

            });

            EmployeeDB.Instance.AddEmployee(new Employee
            {
                Name = "Natasa",
                Surname = "Subic",
                Username = "naci",
                Password = "naci",
                Position = PositionEnum.SM.ToString(),
                StartTime = "10.00",
                EndTime = "17.00",
                Login = false,
                PasswordUpadateDate = DateTime.Now,
                HiringCompanyId = HiringCompanyDB.Instance.GetCompany(Thread.CurrentThread.ManagedThreadId)

            });

            EmployeeDB.Instance.AddEmployee(new Employee
            {
                Name = "Milica",
                Surname = "Kapetina",
                Username = "mici",
                Password = "mici",
                Position = PositionEnum.PO.ToString(),
                StartTime = "09.00",
                EndTime = "16.00",
                Login = false,
                PasswordUpadateDate = DateTime.Now,
                HiringCompanyId = HiringCompanyDB.Instance.GetCompany(Thread.CurrentThread.ManagedThreadId)

            });
        }
    }
}