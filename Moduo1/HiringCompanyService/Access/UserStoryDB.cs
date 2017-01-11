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
    }
}
