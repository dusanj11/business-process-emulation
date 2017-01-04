using HiringCompanyContract.Data;
using System.Collections.Generic;
using System.Linq;

namespace HiringCompanyService.Access
{
    public class EmployeeDB : IEmployeeDB
    {
        private static IEmployeeDB myDB;
        private static object lockThis = new object();

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
            using (AccessDB access = new AccessDB())
            {
                access.Actions.Add(action);
                int i = access.SaveChanges();

                if (i > 0)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        ///     Return list that represents registered users
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>(20);

            using (var access = new AccessDB())
            {
                foreach (var em in access.Actions)
                {
                    if (em.Login)
                    {
                        employees.Add(em);
                    }
                }
            }
            return employees;
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
            Employee employee = null;

            using (var access = new AccessDB())
            {
                foreach (var em in access.Actions)
                {
                    if (em.Username.ToString().Equals(username) && em.Password.ToString().Equals(password))
                    {
                        employee = em;
                        break;
                    }
                }
            }
            return employee;
        }

        public bool ChangeEmployeePosition(string username, Employee.PositionEnum position)
        {
            using (var access = new AccessDB())
            {
                access.Actions.FirstOrDefault(f => f.Username == username).Position = position.ToString();
                //em.Position = position.ToString();
                int i = access.SaveChanges();

                if (i > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public bool ChangeEmployeePassword(string username, string oldPassword, string newPassword)
        {
            using (var access = new AccessDB())
            {
                access.Actions.FirstOrDefault(f => f.Username.Equals(username) && f.Password.Equals(oldPassword)).Password = newPassword;

                int i = access.SaveChanges();

                if (i > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public bool UpdateEmployee(Employee employee)
        {
            using (var access = new AccessDB())
            {
                //access.Actions.Attach(employee);

                access.Entry(employee).State = System.Data.Entity.EntityState.Modified;

                int i = access.SaveChanges();

                if(i>0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}