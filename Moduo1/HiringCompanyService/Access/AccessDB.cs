using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiringCompanyData;

namespace HiringCompanyService.Access
{
    public class AccessDB : DbContext
    {
        public AccessDB() : base("HiringCompanyDB") { }

        public DbSet<Employee> Actions { get; set; }

        public DbSet<HiringCompany> HcActions { get; set; }

        public DbSet<Project> PrActions { get; set; }

        public DbSet<OutsourcingCompany> OcActions { get; set; }
       
    }
}
