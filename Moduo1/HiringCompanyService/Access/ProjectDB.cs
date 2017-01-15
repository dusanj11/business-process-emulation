using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiringCompanyData;
using System.Data.Entity;

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
                    if(project.Company != null)
                    {
                        access.OcActions.Attach(project.Company);
                    }
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

        public Project GetProject(string name)
        {
            using (var access = new AccessDB())
            {
                Project p = access.PrActions.FirstOrDefault(f => f.Name.Equals(name));

                if ( p == null)
                {
                    log.Warn("Project with specified name doesn't exist in DB.");
                }
                else
                {
                    log.Info("Successfully returned project from DB.");
                }

                return p;
            }
        }

        public List<Project> GetProjects()
        {

            log.Debug("Enter GetProjects method.");
            using (var access = new AccessDB())
            {
                List<Project> ret = new List<Project>();
                foreach (var pr in access.PrActions)
                {
                    ret.Add(pr);
                }

                log.Info("Successfully returned list of projects.");
                return ret;
            }
        }

        public List<UserStory> GetProjectUserStory(string projectName)
        {
            using (var access = new AccessDB())
            {
                List<UserStory> ret = new List<UserStory>();

                var userStories = access.UsAction.Include(x => x.Project);

                foreach (var us in userStories)
                {
                    if (us.Project.Name.Equals(projectName))
                    {
                        UserStory userStory = new UserStory();
                        userStory.Description = us.Description;
                        userStory.Id = us.Id;
                        userStory.Name = us.Name;
                        userStory.Progress = us.Progress;
                        userStory.UserStoryState = us.UserStoryState;
                        userStory.WeightOfUserStory = us.WeightOfUserStory;

                        ret.Add(userStory);
                    }
                }

                log.Info("Successfully returned user stories for given project.");
                return ret; 
            }
        }

        public List<UserStory> GetProjectPendingUserStory(string projectName)
        {
            using (var access = new AccessDB())
            {
                List<UserStory> ret = new List<UserStory>();

                var userStories = access.UsAction.Include(x => x.Project);

                foreach (var us in userStories)
                {
                    if (us.Project.Name.Equals(projectName) && us.UserStoryState.Equals(UserStoryState.Pending))
                    {
                        UserStory userStory = new UserStory();
                        userStory.Description = us.Description;
                        userStory.Id = us.Id;
                        userStory.Name = us.Name;
                        userStory.Progress = us.Progress;
                        userStory.UserStoryState = us.UserStoryState;
                        userStory.WeightOfUserStory = us.WeightOfUserStory;

                        ret.Add(userStory);
                    }
                }

                log.Info("Successfully returned user stories for given project.");
                return ret;
            }
        }

        public List<Project> GetProjects(int hiringCompanyId)
        {
            log.Debug("Enter GetProjects for specified hiring company method.");
            using (var access = new AccessDB())
            {
                List<Project> ret = new List<Project>();
                foreach (var pr in access.PrActions.Include(x => x.HiringCompany))
                {
                    if (pr.HiringCompany.IDHc == hiringCompanyId)
                    {
                        Project p = new Project();
                        p.Approved = pr.Approved;
                        p.Description = pr.Description;
                        p.EndDate = pr.EndDate;
                        p.Ended = pr.Ended;
                        p.Id = pr.Id;
                        p.Name = pr.Name;
                        p.Progress = pr.Progress;
                        p.ProjectState = pr.ProjectState;
                        p.StartDate = pr.StartDate;
                       
                        ret.Add(p);
                    }
                    
                }

                log.Info("Successfully returned list of projects.");
                return ret;
            }
        }

        public bool MarkProjectEnded(Project p)
        {
            using (var access = new AccessDB())
            {
                Project project = access.PrActions.FirstOrDefault(f => f.Id == p.Id);

                if(project != null)
                {
                    project.Ended = true;

                    int i = access.SaveChanges();
                    if (i > 0)
                    {
                        log.Info("Successfully marked project as ended.");
                        return true;
                    }

                    log.Warn("Failed to mark project as ended.");
                    return false;
                }
                else
                {
                    log.Warn("Project with specified id doesn't exists. ");
                    return false;
                }
            }
        }

        public bool SetOcToProject(string projectName, int outsourcingCompanyId)
        {
            using (var access = new AccessDB())
            {
                Project p = access.PrActions.FirstOrDefault(f => f.Name.Equals(projectName));

                if (p != null)
                {
                    OutsourcingCompany oc = access.OcActions.FirstOrDefault(f => f.IdFromOutSourcingDB == outsourcingCompanyId);

                    if (oc != null)
                    {
                        p.Company = oc;
                        access.OcActions.Attach(p.Company);

                        
                    }
                    else
                    {
                        log.Warn("Outsourcing company doesn't exists.");

                    }

                    int i = access.SaveChanges();

                    if (i > 0)
                    {
                        log.Info("Successfully assigned project to Outsourcing company.");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    log.Warn("Project doesn't exists.");
                    return false;
                }

                
            }
        }

        public bool UpdateProject(Project p)
        {
            using (var access = new AccessDB())
            {
                Project pr = access.PrActions.FirstOrDefault(f => f.Name.Equals(p.Name));

                if (pr != null)
                {
                    pr.Approved = p.Approved;
                    pr.Description = p.Description;
                    pr.EndDate = p.EndDate;
                    pr.Ended = p.Ended;
                    pr.Name = p.Name;
                    pr.Progress = p.Progress;
                    pr.EndDate = p.EndDate;

                    int i = access.SaveChanges();

                    if (i>0)
                    {
                        log.Info("Project successfully updated.");
                        return true;
                    }
                    return false;
                }
                else
                {
                    log.Warn("Project doesn't exists in DB");
                    return false;
                }
            }
        }
    }
}
