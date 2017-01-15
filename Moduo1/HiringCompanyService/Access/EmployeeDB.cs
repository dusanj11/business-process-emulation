using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace HiringCompanyService.Access
{
    public class EmployeeDB : IEmployeeDB
    {
        private static IEmployeeDB myDB;
        private static object lockThis = new object();

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static IEmployeeDB Instance
        {
            get
            {
                if (myDB == null)
                {
                    myDB = new EmployeeDB();
                }

                return myDB;
            }
            set
            {
                if (myDB == null)
                {
                    myDB = value;
                }
            }
        }

        public static object LockThis
        {
            get
            {
                return lockThis;
            }

            set
            {
                lockThis = value;
            }
        }

        /// <summary>
        ///     DB insert action
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public bool AddEmployee(Employee action)
        {
            Log.Debug("Enter AddEmployee method.");
            using (AccessDB access = new AccessDB())
            {
                Employee em = access.Actions.FirstOrDefault(f => f.Username.Equals(action.Username));
                if (em == null)
                {
                    ///In order to avoid the duplication you must attach the related entity to the context
                    access.HcActions.Attach(action.HiringCompanyId);

                    access.Actions.Add(action);

                    int i = access.SaveChanges();

                    if (i > 0)
                    {
                        Log.Info("SaveChanges to DB success.");
                        return true;
                    }
                    Log.Warn("SaveChanges return 0");
                    return false;
                }
                else
                {
                    Log.Warn("User  with username you are trying to add to the database, already exists!");
                    return false;
                }
            }
        }

        /// <summary>
        ///     Return list that represents registered users
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetEmployees()
        {
            Log.Debug("Enter GetEmployees method.");
            using (var access = new AccessDB())
            {
                List<Employee> employees = new List<Employee>(20);

                foreach (var em in access.Actions)
                {
                    if (em.Login)
                    {
                        employees.Add(em);
                    }
                }
                Log.Info("Successfully returned list of employees");
                return employees;
            }
        }

        /// <summary>
        ///     Method returns instance of Employee only if username and password maches
        ///     return null if it doesnt
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Employee GetEmployee(string username, string password)
        {
            Log.Debug("Enter GetEmployee method.");
            using (var access = new AccessDB())
            {
                Employee employee = access.Actions.FirstOrDefault(f => f.Username.Equals(username) && f.Password.Equals(password));

                Log.Info("Successfully returned employee");
                return employee;
            }
        }

        public bool ChangeEmployeePosition(string username, string position)
        {
            Log.Debug("Enter ChangeEmployeePosition method.");
            using (var access = new AccessDB())
            {
                Employee em = access.Actions.FirstOrDefault(f => f.Username.Equals(username));
                if (em != null)
                {
                    //access.Actions.FirstOrDefault(f => f.Username == username).Position = position.ToString();
                    em.Position = position.ToString();
                    access.Entry(em).State = System.Data.Entity.EntityState.Modified;

                    int i = access.SaveChanges();

                    if (i > 0)
                    {
                        Log.Info("Successfully updated DB");
                        return true;
                    }
                    Log.Warn("Failed to update DB");
                    return false;
                }
                else
                {
                    Log.Warn("Employee with that username does not exist. Failed chainging position.");
                    return false;
                }
            }
        }

        public bool ChangeEmployeePassword(string username, string oldPassword, string newPassword)
        {
            Log.Debug("Enter ChangeEmployeePassword method.");
            using (var access = new AccessDB())
            {
                //access.Actions.FirstOrDefault(f => f.Username.Equals(username) && f.Password.Equals(oldPassword)).Password = newPassword;

                Employee em = access.Actions.FirstOrDefault(f => f.Username.Equals(username) && f.Password.Equals(oldPassword));
                if (em != null)
                {
                    em.Password = newPassword;
                    em.PasswordUpadateDate = DateTime.Now;

                    access.Entry(em).State = System.Data.Entity.EntityState.Modified;

                    int i = access.SaveChanges();

                    if (i > 0)
                    {
                        Log.Info("Successfully updated DB");
                        return true;
                    }
                    Log.Warn("Failed to update DB");
                    return false;
                }
                else
                {
                    Log.Warn("Employee with that username does not exist. Failed chainging password.");
                    return false;
                }
               
            }
        }

        public bool UpdateEmployee(Employee employee)
        {
            Log.Debug("Enter UpdateEmployee method.");
            using (var access = new AccessDB())
            {
                //access.Actions.Attach(employee);
                Employee em = access.Actions.FirstOrDefault(f => f.Email.Equals(employee.Email));
                if (em != null)
                {
                    Log.Debug("Employee exists");
                    em.Email = employee.Email;
                    em.EndTime = employee.EndTime;
                    em.HiringCompanyId = employee.HiringCompanyId;
                    em.Login = employee.Login;
                    em.Name = employee.Name;
                    em.Password = employee.Password;
                    em.PasswordUpadateDate = employee.PasswordUpadateDate;
                    em.Position = employee.Position;
                    em.StartTime = employee.StartTime;
                    em.Surname = employee.Surname;
                    em.Username = employee.Username;

                   
                   
                    //access.Entry(employee).State = System.Data.Entity.EntityState.Modified;

                    int i = access.SaveChanges();

                    if (i > 0)
                    {
                        Log.Info("Successfully updated DB");
                        return true;
                    }
                    Log.Warn("Failed to update DB");
                    return false;
                }
                else
                {
                    Log.Warn("Employee with that username does not exist. Failed updating employee.");
                    return false;
                }
            }
        }

        public bool EmployeeLogIn(string username)
        {
            Log.Debug("Enter EmployeeLogIn method.");
            using (var access = new AccessDB())
            {

                Employee emp = access.Actions.FirstOrDefault(f => f.Username.Equals(username));

                if (emp != null)
                {
                    //access.Actions.FirstOrDefault(f => f.Username.Equals(username)).Login = true;
                    emp.Login = true;
                    access.Entry(emp).State = System.Data.Entity.EntityState.Modified;

                    int i = access.SaveChanges();

                    if (i > 0)
                    {
                        Log.Info("Successfully updated DB");
                        return true;
                    }
                    Log.Warn("Failed to update DB");
                    return false;
                }
                else
                {
                    Log.Warn("Employee with that username does not exist. Failed to login.");
                    return false;
                }
           
            }
        }

        public bool EmployeeLogOut(string username)
        {
            Log.Debug("Enter EmployeeLogOut method.");
            using (var access = new AccessDB())
            {

                Employee emp = access.Actions.FirstOrDefault(f => f.Username.Equals(username));

                if (emp != null)
                {
                    //access.Actions.FirstOrDefault(f => f.Username.Equals(username)).Login = false;
                    emp.Login = false;
                    access.Entry(emp).State = System.Data.Entity.EntityState.Modified;

                    int i = access.SaveChanges();

                    if (i > 0)
                    {
                        Log.Info("Successfully updated DB");
                        return true;
                    }
                    Log.Warn("Failed to update DB");
                    return false;
                }
                else
                {
                    Log.Warn("Employee with that username does not exist. Failed to logout.");
                    return false;
                }

            }
        }

        public String GetEmployeeEmail(string username)
        {
            Log.Debug("Enter GetEmployeeEmail method.");
            using (var access = new AccessDB())
            {
                Employee emp = access.Actions.FirstOrDefault(f => f.Username.Equals(username));

                if (emp != null)
                {
                    Log.Info("Successfully returned employee email");
                    return emp.Email;
                }
                else
                {
                    Log.Warn("Employee with that username does not exist. Failed to retrieve email.");
                    return string.Empty;
                }
                
            }
        }

        public List<Employee> GetAllNotSignedInEmployees()
        {
            Log.Debug("Enter GetAllNotSignedInEmployees method.");
            using (var access = new AccessDB())
            {
                List<Employee> employees = new List<Employee>(20);

                foreach (var em in access.Actions)
                {
                    if (!em.Login)
                    {
                        employees.Add(em);
                    }
                }
                Log.Info("Successfully returned not signedIn employees");
                return employees;
            }
        }

        public List<Employee> GetReallyEmployees()
        {
            Log.Debug("Enter GetReallyEmployees method.");
            using (var access = new AccessDB())
            {
                List<Employee> employees = new List<Employee>(20);

                foreach (var em in access.Actions)
                {
                        employees.Add(em);
                }
                Log.Info("Successfully returned list of employees");
                return employees;
            }
        }

        public int GetHcIdForUser(string username)
        {
            using (var access = new AccessDB())
            {

                Log.Info("Successfully returned company id for employee username.");
                var employee = access.Actions.Include(x => x.HiringCompanyId).FirstOrDefault(f => f.Username.Equals(username));

                return employee.HiringCompanyId.IDHc;

            }


        }
    }
}