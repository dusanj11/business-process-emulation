using HiringCompanyContract;
using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Client
{
    public class ClientProxy : ChannelFactory<IHiringCompany>, IHiringCompany, IDisposable
    {
        private IHiringCompany factory;

        public ClientProxy(NetTcpBinding binding, string address) : base(binding, address)
        {
            factory = this.CreateChannel();
        }

        public void Dispose()
        {
            try
            {
                //if (factory != null)
                //{
                //    factory = null;

                //}
                //this.Close();
                if (State != CommunicationState.Faulted)
                {
                    Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Dispose exception: {0}", e.Message);
            }
            finally
            {
                if (State != CommunicationState.Closed)
                {
                    Abort();
                }
            }
        }

        public List<Employee> GetAllEmployees()
        {
            try
            {
                return factory.GetAllEmployees();
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
                return factory.GetEmployee(username, password);
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
                return factory.AddEmployee(employee);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: AddEmployee: \n{0}", e.Message);
                return false;
            }
        }

        public bool ChangeEmployeePosition(string username, PositionEnum position)
        {
            try
            {
                return factory.ChangeEmployeePosition(username, position);
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
                return factory.UpdateEmployee(employee);
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
                return factory.ChangePassword(username, oldPassword, newPassword);
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
                return factory.EmployeeLogIn(username);
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
                return factory.EmployeeLogOut(username);
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
                return factory.AddHiringCompany(company);
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
                return factory.GetHiringCompany(id);
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
                return factory.AddProjectDefinition(project);
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
                return factory.GetProjects();
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
                return factory.SendDelayingEmail(username);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: GetProjects: \n{0}", e.Message);
                return false;
            }
        }
    }
}