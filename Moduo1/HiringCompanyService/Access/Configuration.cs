using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace HiringCompanyService.Access
{
    public class Configuration : DbMigrationsConfiguration<AccessDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;   // sprecavanje gubljenja podataka prilikom brisanja nekog property prilikom mapiranja 
            ContextKey = "EmployeeDB";
        }
    }
}
