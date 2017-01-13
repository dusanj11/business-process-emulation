using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiringCompanyData;

namespace HiringCompanyService.Access
{
    public interface IProjectDB
    {
        bool AddProject(Project project);

        List<Project> GetProjects();

        List<Project> GetProjects(int hiringCompanyId);

        Project GetProject(string name);

        List<UserStory> GetProjectUserStory(string projectName);

        List<UserStory> GetProjectPendingUserStory(string projectName);

        bool MarkProjectEnded(Project p);
    }
}
