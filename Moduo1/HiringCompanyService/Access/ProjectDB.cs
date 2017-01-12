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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static IProjectDB myDB;
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
            log.Debug("Enter AddProject method.");
            using (var access = new AccessDB())
            {

                Project proj = access.PrActions.FirstOrDefault(f => f.Name.Equals(project.Name));
                
                if (proj == null)
                {
                    access.HcActions.Attach(project.HiringCompany);
                    access.Actions.Attach(project.ProductOwner);
                    access.PrActions.Add(project);

                    int i = access.SaveChanges();

                    if (i > 0)
                    {
                        log.Info("Successfully updated DB.");
                        return true;
                    }
                    log.Warn("Failed to update DB.");
                    return false;
                }
                else
                {
                    log.Warn("Project with specified name already exists in DB");
                    return false;
                }
               

            }
        }

        public List<Project> GetProjects()
        {

            log.Debug("Enter GetProjects method.");
            List<Project> ret = new List<Project>();

            using (var access = new AccessDB())
            {
                foreach (var pr in access.PrActions)
                {
                    ret.Add(pr);
                }

                log.Info("Successfully returned list of projects.");
                return ret;
            }
        }
    }
}
