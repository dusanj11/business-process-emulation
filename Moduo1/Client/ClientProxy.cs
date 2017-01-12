using HiringCompanyContract;
using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceModel;

namespace Client
{
    public class ClientProxy : IHiringCompany, IDisposable
    {
        private static IHiringCompany proxy;

        private static ChannelFactory<IHiringCompany> factory;

        private static string address = ConfigurationManager.AppSettings["HiringCompanyServiceAddress"];

        public static IHiringCompany Instance
        {
            get
            {
                if (proxy == null)
                {
                    factory = new ChannelFactory<IHiringCompany>(new NetTcpBinding(), new EndpointAddress(address));
                    proxy = factory.CreateChannel();
                    ////System.ServiceModel.ClientBase<IHiringCompany> cb = proxy as System.ServiceModel.ClientBase<IHiringCompany>;
                    ////CommunicationState st = cb.State;
                    //CommunicationState st = factory.State;
                    //ICommunicationObject co = proxy as ICommunicationObject;
                    ////co.Opening += Co_Opening;
                    //CommunicationState sto = co.State;

                    IContextChannel cc = proxy as IContextChannel;
                    Console.WriteLine(cc.State);



                }

                return proxy;
            }
            set
            {
                if (proxy == null)
                {
                    proxy = value;
                }
            }
        }

        private void Cc_Faulted(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            try
            {
                if (factory != null)
                {
                    factory = null;

                }
                factory.Close();

            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("Communication exception: {0}", ce.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Communication exception: {0}", e.Message);
            }
        }

        public List<Employee> GetAllEmployees()
        {
            try
            {
                return proxy.GetAllEmployees();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: GetAllEmployees: \n{0}", e.Message);
                return null;
            }
        }

        public Employee GetEmployee(string username, string password)
        {
            try
            {
                return proxy.GetEmployee(username, password);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: GetEmployee: \n{0}", e.Message);
                return null;
            }
        }

        public bool AddEmployee(Employee employee)
        {
            try
            {
                return proxy.AddEmployee(employee);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: AddEmployee: \n{0}", e.Message);
                return false;
            }
        }

        public bool ChangeEmployeePosition(string username, string position)
        {
            try
            {
                return proxy.ChangeEmployeePosition(username, position);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: ChangeEmployeePosition: \n{0}", e.Message);
                return false;
            }
        }

        public bool UpdateEmployee(Employee employee)
        {
            try
            {
                return proxy.UpdateEmployee(employee);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: UpdateEmployee: \n{0}", e.Message);
                return false;
            }
        }

        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            try
            {
                return proxy.ChangePassword(username, oldPassword, newPassword);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: ChangePassword: \n{0}", e.Message);
                return false;
            }
        }

        public bool EmployeeLogIn(string username)
        {
            try
            {
                return proxy.EmployeeLogIn(username);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: EmployeeLogIn: \n{0}", e.Message);
                return false;
            }
        }

        public bool EmployeeLogOut(string username)
        {
            try
            {
                return proxy.EmployeeLogOut(username);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: EmployeeLogOut: \n{0}", e.Message);
                return false;
            }
        }

        public bool AddHiringCompany(HiringCompany company)
        {
            try
            {
                return proxy.AddHiringCompany(company);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: AddHiringCompany: \n{0}", e.Message);
                return false;
            }
        }

        public HiringCompany GetHiringCompany(int id)
        {
            try
            {
                return proxy.GetHiringCompany(id);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: GetHiringCompany: \n{0}", e.Message);
                return null;
            }
        }

        public bool AddProjectDefinition(Project project)
        {
            try
            {
                return proxy.AddProjectDefinition(project);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: AddProjectDefinition: \n{0}", e.Message);
                return false;
            }
        }

        public List<Project> GetProjects()
        {
            try
            {
                return proxy.GetProjects();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: GetProjects: \n{0}", e.Message);
                return null;
            }
        }

        public bool SendDelayingEmail(string username)
        {
            try
            {
                return proxy.SendDelayingEmail(username);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: GetProjects: \n{0}", e.Message);
                return false;
            }
        }


        public List<Employee> GetAllNotSignedInEmployees()
        {
            try
            {
                return proxy.GetAllNotSignedInEmployees();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: GetProjects: \n{0}", e.Message);
                return null;
            }
        }

        public List<Employee> GetReallyAllEmployees()
        {
            try
            {
                return proxy.GetReallyAllEmployees();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: GetReallyAllEmployees: \n{0}", e.Message);
                return null;
            }
        }

        public bool AddPartnershipToDB(HiringCompany hc, OutsourcingCompany oc)
        {
            try
            {
                return proxy.AddPartnershipToDB(hc,oc);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: AddPartnershipToDB: \n{0}", e.Message);
                return false;
            }
        }

        public List<OutsourcingCompany> GetPartnershipOc(int hiringCompany)
        {
            try
            {
                return proxy.GetPartnershipOc(hiringCompany);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: GetPartnershipOc: \n{0}", e.Message);
                return null;
            }
        }

        public bool AddOutsourcingCompany(OutsourcingCompany oc)
        {
            try
            {
                return proxy.AddOutsourcingCompany(oc);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: AddOutsourcingCompany: \n{0}", e.Message);
                return false;
            }
        }

        public OutsourcingCompany GetOutsourcingCompany(string name)
        {
            try
            {
                return proxy.GetOutsourcingCompany(name);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: GetOutsourcingCompany: \n{0}", e.Message);
                return null;
            }
        }
    }
}