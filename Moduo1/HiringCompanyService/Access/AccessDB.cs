using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiringCompanyContract.Data;

namespace HiringCompanyService.Access
{
    public class AccessDB : DbContext
    {
        public AccessDB() : base("HiringCompanyDB") { }

        public DbSet<Employee> Actions { get; set; }
    }
}
