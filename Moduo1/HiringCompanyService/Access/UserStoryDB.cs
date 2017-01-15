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
                UserStory uStory = access.UsAction.FirstOrDefault(f => f.Name.Equals(us.Name));
                if(uStory == null)
                {
                    access.PrActions.Attach(us.Project);
                    access.UsAction.Add(us);

                    int i = access.SaveChanges();

                    if(i > 0)
                    {
                        
                        return true;
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool ChangeUserStoryState(int id, UserStoryState state)
        {
            using(var access = new AccessDB())
            {
                UserStory us = access.UsAction.FirstOrDefault(f => f.Id == id);

                if (us != null)
                {
                    us.UserStoryState = state;

                    int i = access.SaveChanges();

                    if(i > 0)
                    {
                        
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
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

                return ret;
            }
        }

        public UserStory GetUserStoryFromId(int id)
        {
            using (var access = new AccessDB())
            {
                UserStory us = access.UsAction.FirstOrDefault(f => f.Id == id);

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

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    
                    return false;
                }

            }
        }
    }
}
