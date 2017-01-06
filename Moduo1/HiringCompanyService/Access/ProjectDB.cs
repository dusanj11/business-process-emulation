using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiringCompanyData;

namespace HiringCompanyService.Access
{
    public class ProjectDB : IProjectDB
    {
        public static IProjectDB myDB;
        public static IProjectDB Instance
        {
            get
            {
                if (myDB == null)
                {
                    myDB = new ProjectDB();
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

     
        public bool AddProject(Project project)
        {
            using (var access = new AccessDB())
            {
                access.HcActions.Attach(project.HiringCompany);

                access.PrActions.Add(project);

                int i = access.SaveChanges();

                if (i > 0)
                {
                    return true;
                }
                return false;

            }
        }
    }
}
