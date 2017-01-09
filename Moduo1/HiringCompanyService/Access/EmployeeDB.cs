using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HiringCompanyService.Access
{
    public class EmployeeDB : IEmployeeDB
    {
        private static IEmployeeDB myDB;
        private static object lockThis = new object();

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
            log.Debug("Enter AddEmployee method.");
            using (AccessDB access = new AccessDB())
            {
                ///In order to avoid the duplication you must attach the related entity to the context
                access.HcActions.Attach(action.HiringCompanyId);

                access.Actions.Add(action);

                int i = access.SaveChanges();

                if (i > 0)
                {
                    log.Info("SaveChanges to DB success.");
                    return true;
                }
                log.Warn("SaveChanges return 0");
                return false;
            }
        }

        /// <summary>
        ///     Return list that represents registered users
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetEmployees()
        {
            log.Debug("Enter GetEmployees method.");
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
                log.Info("Successfully returned list of employees");
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
            log.Debug("Enter GetEmployee method.");
            using (var access = new AccessDB())
            {
                Employee employee = access.Actions.FirstOrDefault(f => f.Username.Equals(username) && f.Password.Equals(password));

                log.Info("Successfully returned employee");
                return employee;
            }
        }

        public bool ChangeEmployeePosition(string username, PositionEnum position)
        {
            log.Debug("Enter ChangeEmployeePosition method.");
            using (var access = new AccessDB())
            {
                access.Actions.FirstOrDefault(f => f.Username == username).Position = position.ToString();
                //em.Position = position.ToString();
                int i = access.SaveChanges();

                if (i > 0)
                {
                    log.Info("Successfully updated DB");
                    return true;
                }
                log.Warn("Failed to update DB");
                return false;
            }
        }

        public bool ChangeEmployeePassword(string username, string oldPassword, string newPassword)
        {
            log.Debug("Enter ChangeEmployeePassword method.");
            using (var access = new AccessDB())
            {
                //access.Actions.FirstOrDefault(f => f.Username.Equals(username) && f.Password.Equals(oldPassword)).Password = newPassword;

                Employee em = access.Actions.FirstOrDefault(f => f.Username.Equals(username) && f.Password.Equals(oldPassword));
                if (em != null)
                {
                    em.Password = newPassword;
                    em.PasswordUpadateDate = DateTime.Now;
                }

                access.Entry(em).State = System.Data.Entity.EntityState.Modified;

                int i = access.SaveChanges();

                if (i > 0)
                {
                    log.Info("Successfully updated DB");
                    return true;
                }
                log.Warn("Failed to update DB");
                return false;
            }
        }

        public bool UpdateEmployee(Employee employee)
        {
            log.Debug("Enter UpdateEmployee method.");
            using (var access = new AccessDB())
            {
                //access.Actions.Attach(employee);

                access.Entry(employee).State = System.Data.Entity.EntityState.Modified;

                int i = access.SaveChanges();

                if (i > 0)
                {
                    log.Info("Successfully updated DB");
                    return true;
                }
                log.Warn("Failed to update DB");
                return false;
            }
        }

        public bool EmployeeLogIn(string username)
        {
            log.Debug("Enter EmployeeLogIn method.");
            using (var access = new AccessDB())
            {
                access.Actions.FirstOrDefault(f => f.Username.Equals(username)).Login = true;

                int i = access.SaveChanges();

                if (i > 0)
                {
                    log.Info("Successfully updated DB");
                    return true;
                }
                log.Warn("Failed to update DB");
                return false;
            }
        }

        public bool EmployeeLogOut(string username)
        {
            log.Debug("Enter EmployeeLogOut method.");
            using (var access = new AccessDB())
            {
                access.Actions.FirstOrDefault(f => f.Username.Equals(username)).Login = false;

                int i = access.SaveChanges();

                if (i > 0)
                {
                    log.Info("Successfully updated DB");
                    return true;
                }
                log.Warn("Failed to update DB");
                return false;
            }
        }

        public String GetEmployeeEmail(string username)
        {
            log.Debug("Enter GetEmployeeEmail method.");
            using (var access = new AccessDB())
            {
                Employee emp = access.Actions.FirstOrDefault(f => f.Username.Equals(username));

                log.Info("Successfully returned employee email");
                return emp.Email;
            }
        }

        public List<Employee> GetAllNotSignedInEmployees()
        {
            log.Debug("Enter GetAllNotSignedInEmployees method.");
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
                log.Info("Successfully returned not signedIn employees");
                return employees;
            }
        }
    }
}