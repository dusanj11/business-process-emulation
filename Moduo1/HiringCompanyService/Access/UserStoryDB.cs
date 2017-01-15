using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiringCompanyData;

namespace HiringCompanyService.Access
{
    public class UserStoryDB : IUserStoryDB
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static IUserStoryDB myDB;

        public static IUserStoryDB Instance
        {
            get
            {
                if (myDB == null)
                {
                    myDB = new UserStoryDB();
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

        public bool AddUserStory(UserStory us)
        {
            using (var access = new AccessDB())
            {
                Log.Info("Enter AddUserStory");
                UserStory uStory = access.UsAction.FirstOrDefault(f => f.Name.Equals(us.Name));
                if (uStory == null)
                {
                    access.PrActions.Attach(us.Project);
                    access.UsAction.Add(us);

                    int i = access.SaveChanges();

                    if (i > 0)
                    {
                        Log.Info("Successfullye added user story to DB.");
                        return true;
                    }
                    Log.Warn("Failed to add user story do DB.");
                    return false;
                }
                else
                {
                    Log.Warn("User story allready exists in DB.");
                    return false;
                }
            }
        }

        public bool ChangeUserStoryState(int id, UserStoryState state)
        {
            using (var access = new AccessDB())
            {

                Log.Info("Enter Change user story state");
                UserStory us = access.UsAction.FirstOrDefault(f => f.Id == id);

                if (us != null)
                {
                    us.UserStoryState = state;

                    int i = access.SaveChanges();

                    if (i > 0)
                    {
                        Log.Info("Successfully changed user story state.");
                        return true;
                    }
                    else
                    {
                        Log.Warn("Failed to changed user story state.");
                        return false;
                    }
                }
                else
                {
                    Log.Warn("User story doesn't exists in DB.");
                    return false;
                }
            }
        }

        public List<UserStory> GetUserStory(string projectName)
        {
            using (var access = new AccessDB())
            {
                List<UserStory> ret = new List<UserStory>();

                foreach (UserStory us in access.UsAction)
                {
                    if (us.Project.Name.Equals(projectName))
                    {
                        ret.Add(us);
                    }
                }

                Log.Info("Successfully returned user stories for specified project name.");
                return ret;
            }
        }

        public UserStory GetUserStoryFromId(int id)
        {
            using (var access = new AccessDB())
            {
                UserStory us = access.UsAction.FirstOrDefault(f => f.Id == id);

                if (us != null)
                {
                    Log.Info("Successfully returned user story for specified id.");
                }
                else
                {
                    Log.Warn("User story for specified id doesn't exist.");
                }
              
                return us;
            }
        }

        public bool UpdateUserStory(UserStory us)
        {
            using (var access = new AccessDB())
            {
                UserStory u = access.UsAction.FirstOrDefault(f => f.Name.Equals(us.Name));
                
                if (u != null)
                {
                    u.IdFromOcDB = us.Id;
                    u.Description = us.Description;
                    u.Name = us.Name;
                    u.Progress = us.Progress;
                    u.UserStoryState = us.UserStoryState;
                    u.WeightOfUserStory = us.WeightOfUserStory;

                    int i = access.SaveChanges();

                    if (i > 0)
                    {
                        Log.Info("Successfully update user story.");
                        return true;
                    }
                    else
                    {
                        Log.Warn("Failed to update user story.");
                        return false;
                    }
                }
                else
                {
                    Log.Warn("User story for specified name doesn't exist.");
                    return false;
                }

            }
        }
    }
}
