using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiringCompanyContract;
using HiringCompanyContract.Data;

namespace HiringCompanyService.Access
{
    public class EmployeeDB : IEmployeeDB
    {
        private static IEmployeeDB myDB;

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

        public bool AddAction(Employee action)
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

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>(20);

            using (var access = new AccessDB())
            {
                foreach(var ca in access.Actions)
                {
                    //if(ca.Login)
                        employees.Add(ca);
                }
            }
            return employees;
        }

    }
}
