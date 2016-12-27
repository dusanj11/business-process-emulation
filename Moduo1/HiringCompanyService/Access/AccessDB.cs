using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiringCompanyService.Data;

namespace HiringCompanyService.Access
{
    public class AccessDB : DbContext
    {
        public AccessDB() : base("calcDB") { }

        public DbSet<Employee> Actions { get; set; }
    }
}
