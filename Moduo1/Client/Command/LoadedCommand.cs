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

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
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
                        log.Debug("proxy poziv - AddHiringCompany"); 
                        proxy.AddHiringCompany(company);

                        //HiringCompany hc = proxy.GetHiringCompany(threadId);

                        //Employee testEmp = new Employee();
                        //testEmp.Name = "Milica";
                        //testEmp.Surname = "Kapetina";
                        //testEmp.Username = "mica";
                        //testEmp.Password = "mica";
                        //testEmp.Position = PositionEnum.CEO.ToString();
                        //testEmp.StartTime = "10.00";
                        //testEmp.EndTime = "17.00";
                        //testEmp.Login = false;
                        //testEmp.Email = "marko.jelaca@gmail.com";
                        //testEmp.PasswordUpadateDate = DateTime.Now;
                        //testEmp.HiringCompanyId = hc;

                        //proxy.AddEmployee(testEmp);


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


           
        }
    }
}