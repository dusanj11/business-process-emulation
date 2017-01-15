using HiringCompanyData;
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
                int threadId = Thread.CurrentThread.ManagedThreadId;
                HiringCompany company = new HiringCompany();
                company.Name = "HC";
                company.Ceo = "Marko Jelaca";
                company.CompanyIdThr = threadId;

                try
                {
                    log.Debug("proxy poziv - AddHiringCompany");
                    ClientProxy.Instance.AddHiringCompany(company);


                    LoadDB(threadId);


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
            catch (Exception e)
            {
                Console.WriteLine("Error Using: {0}", e.Message);
            }
        }


        public void LoadDB(int threadId)
        { 


            HiringCompany hc = ClientProxy.Instance.GetHiringCompanyForThr(threadId);

            Employee testEmp = new Employee();
            testEmp.Name = "Milica";
            testEmp.Surname = "Kapetina";
            testEmp.Username = "mica";
            testEmp.Password = "mica";
            testEmp.Position = PositionEnum.CEO.ToString();
            testEmp.StartTime = "10.00";
            testEmp.EndTime = "17.00";
            testEmp.Login = false;
            testEmp.Email = "marko.jelaca@gmail.com";
            testEmp.PasswordUpadateDate = DateTime.Now;
            testEmp.HiringCompanyId = hc;

            ClientProxy.Instance.AddEmployee(testEmp);

            Employee testEmp2 = new Employee();
            testEmp2.Name = "Natasa";
            testEmp2.Surname = "Subic";
            testEmp2.Username = "naci";
            testEmp2.Password = "naci";
            testEmp2.Position = PositionEnum.PO.ToString();
            testEmp2.StartTime = "09.00";
            testEmp2.EndTime = "16.00";
            testEmp2.Login = false;
            testEmp2.Email = "natasa.subic94@gmail.com";
            testEmp2.PasswordUpadateDate = DateTime.Now;
            testEmp2.HiringCompanyId = hc;

            ClientProxy.Instance.AddEmployee(testEmp2);

            Employee testEmp3 = new Employee();
            testEmp3.Name = "Dusan";
            testEmp3.Surname = "Jeftic";
            testEmp3.Username = "dule";
            testEmp3.Password = "dule";
            testEmp3.Position = PositionEnum.HR.ToString();
            testEmp3.StartTime = "10.15";
            testEmp3.EndTime = "17.15";
            testEmp3.Login = false;
            testEmp3.Email = "dusan.jeftic11@gmail.com";
            testEmp3.PasswordUpadateDate = DateTime.Now;
            testEmp3.HiringCompanyId = hc;

            ClientProxy.Instance.AddEmployee(testEmp3);

            Employee testEmp4 = new Employee();
            testEmp4.Name = "Marko";
            testEmp4.Surname = "Jelaca";
            testEmp4.Username = "maki";
            testEmp4.Password = "maki";
            testEmp4.Position = PositionEnum.CEO.ToString();
            testEmp4.StartTime = "09.15";
            testEmp4.EndTime = "16.15";
            testEmp4.Login = false;
            testEmp4.Email = "marko.jelaca@gmail.com";
            testEmp4.PasswordUpadateDate = DateTime.Now;
            testEmp4.HiringCompanyId = hc;

            ClientProxy.Instance.AddEmployee(testEmp4);

            //HiringCompanyData.OutsourcingCompany oc = new HiringCompanyData.OutsourcingCompany();
            //oc.Name = "OC1";


            //bool ret = ClientProxy.Instance.AddOutsourcingCompany(oc);

            //HiringCompany hCompany = ClientProxy.Instance.GetHiringCompany(threadId);
            //HiringCompanyData.OutsourcingCompany oCompany = ClientProxy.Instance.GetOutsourcingCompany("OC1");


            //ClientProxy.Instance.AddPartnershipToDB(hCompany, oCompany);

            //Project p = new Project();
            //p.Name = "P1";
            //p.Description = "Opis projekta";
            //p.Company = oCompany;
            //p.EndDate = DateTime.Now;
            //p.Ended = false;
            //p.HiringCompany = hCompany;
            //p.ProductOwner = ClientProxy.Instance.GetEmployee("naci", "naci");
            //p.Progress = 40;
            //p.ProjectState = ProjectState.Accepted;
            //p.StartDate = DateTime.Now;
            //p.Team = null;

            //ClientProxy.Instance.AddProjectDefinition(p);

            //Project p2 = new Project();
            //p2.Name = "P2";
            //p2.Description = "Opis projekta 2";
            //p2.Company = oCompany;
            //p2.EndDate = DateTime.Now;
            //p2.Ended = false;
            //p2.HiringCompany = hCompany;
            //p2.ProductOwner = ClientProxy.Instance.GetEmployee("naci", "naci");
            //p2.Progress = 40;
            //p2.ProjectState = ProjectState.Accepted;
            //p2.StartDate = DateTime.Now;
            //p2.Team = null;

            //ClientProxy.Instance.AddProjectDefinition(p2);

            //UserStory us1 = new UserStory();
            //us1.Description = "Opis Us1";
            //us1.Name = "US1";
            //us1.Progress = 50;
            //us1.Project = ClientProxy.Instance.GetProject("P1");
            //us1.UserStoryState = UserStoryState.Pending;

            //ClientProxy.Instance.AddUserStory(us1);

            //UserStory us2_1 = new UserStory();
            //us2_1.Description = "Opis Us2_1";
            //us2_1.Name = "US2_1";
            //us2_1.Progress = 50;
            //us2_1.Project = ClientProxy.Instance.GetProject("P2");
            //us2_1.UserStoryState = UserStoryState.Pending;

            //ClientProxy.Instance.AddUserStory(us2_1);

            //UserStory us2_2 = new UserStory();
            //us2_2.Description = "Opis Us2_2";
            //us2_2.Name = "US2_2";
            //us2_2.Progress = 50;
            //us2_2.Project = ClientProxy.Instance.GetProject("P2");
            //us2_2.UserStoryState = UserStoryState.Pending;

            //ClientProxy.Instance.AddUserStory(us2_2);


        }
    }
}