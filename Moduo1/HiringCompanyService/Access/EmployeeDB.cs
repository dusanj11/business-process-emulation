﻿using HiringCompanyData;
using System.Collections.Generic;
using System.Linq;
using System;

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
                ///In order to avoid the duplication you must attach the related entity to the context 
                access.HcActions.Attach(action.HiringCompanyId);

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
            

            using (var access = new AccessDB())
            {
                Employee employee = access.Actions.FirstOrDefault(f => f.Username.Equals(username) && f.Password.Equals(password));

                return employee;
            }
            
        }

        public bool ChangeEmployeePosition(string username, PositionEnum position)
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

                if (i > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public bool EmployeeLogIn(string username)
        {
            using (var access = new AccessDB())
            {
                access.Actions.FirstOrDefault(f => f.Username.Equals(username)).Login = true;

                int i = access.SaveChanges();

                if (i > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public bool EmployeeLogOut(string username)
        {
            using (var access = new AccessDB())
            {
                access.Actions.FirstOrDefault(f => f.Username.Equals(username)).Login = false;

                int i = access.SaveChanges();

                if (i > 0)
                {
                    return true;
                }
                return false;
            }
        }


        public String GetEmployeeEmail(string username)
        {
            using (var access = new AccessDB())
            {
               Employee emp =  access.Actions.FirstOrDefault(f => f.Username.Equals(username));

               return emp.Email;
            }
        }


        public List<Employee> GetAllNotSignedInEmployees()
        {
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
                return employees;
            }
        }
    }
}