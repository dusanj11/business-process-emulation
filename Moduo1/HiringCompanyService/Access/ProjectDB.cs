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
    }
}
