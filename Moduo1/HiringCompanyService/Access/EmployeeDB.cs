﻿using HiringCompanyContract.Data;
using System.Collections.Generic;
using System;
using System.Linq;

namespace HiringCompanyService.Access
{
    public class EmployeeDB : IEmployeeDB
    {
        private static IEmployeeDB myDB;
        public static object lockThis = new object();

        public static IEmployeeDB Instance
        {
            get
            {
                if (myDB == null)
                    myDB = new EmployeeDB();

                return myDB;
            }
            set
            {
                if (myDB == null)
                    myDB = value;
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
                    return true;
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
                    if(em.Login)
                        employees.Add(em);
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
                foreach(var em in access.Actions)
                {
                    if(em.Username.ToString().Equals(username) && em.Password.ToString().Equals(password))
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
            //using (var access = new AccessDB())
            //{
            //    Employee em = access.Actions.FirstOrDefault(f => f.Username == username);
            //    em.Position = position.ToString();
            //    access.Actions.
            //}
            throw new NotImplementedException();
        }
    }
}